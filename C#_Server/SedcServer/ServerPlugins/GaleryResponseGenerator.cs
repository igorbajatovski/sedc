using ServerInterfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Net;

namespace ServerPlugins
{
    public class GaleryResponseGenerator : IResponseGenerator
    {   
        public DirectoryInfo FolderPath { get; private set; }

        public GaleryResponseGenerator(string folder)
        {
            FolderPath = new DirectoryInfo(Path.GetFullPath(folder));
        }

        public int Count => throw new NotImplementedException();

        private List<FileSystemInfo> FindAllImagesInFolder(DirectoryInfo startDir, List<FileSystemInfo> fileList = null)
        {
            if (fileList == null)
                fileList = new List<FileSystemInfo>();

            var fileCount = startDir.GetFileSystemInfos().Length;
            if (fileCount > 0)
            {
                foreach(var file in startDir.GetFileSystemInfos())
                {
                    if (file is DirectoryInfo)
                    {
                        fileList = FindAllImagesInFolder(file as DirectoryInfo, fileList);
                        continue;
                    }

                    var imageFile = file as FileInfo;
                    switch(imageFile.Extension)
                    {
                        case ".jpg":
                            fileList.Add(imageFile);
                            break;
                        case ".jpeg":
                            fileList.Add(imageFile);
                            break;
                        case ".jpe":
                            fileList.Add(imageFile);
                            break;
                        case ".gif":
                            fileList.Add(imageFile);
                            break;
                        case ".png":
                            fileList.Add(imageFile);
                            break;
                    }// end of switch
                }// end of foreach
            }// end of if

            return fileList;
        }

        private string GetHTMLImageSrc(FileSystemInfo image)
        {
            return image.FullName.Remove(0, FolderPath.FullName.Length + 1).Replace(Path.DirectorySeparatorChar, '/');
        }

        public async Task<Response> Generate(Request request, ILogger logger)
        {
            // Redirect to URL http://localhost:2019/galery/ImagesWebSite/, if http://localhost:2019/galery/ImagesWebSite is sent.
            // This is needed, otherwise the URL http://localhost:2019/galery/ImagesWebSite/ 
            // will not be pre-appended to the images src when the request is sent
            var requestPath = $"galery/{FolderPath.Name}";
            if (request.Path.Equals(requestPath))
            {
                var host = request.Headers.GetHeader("Host").Split(":").First();
                var port = request.Headers.GetHeader("Host").Split(":").Skip(1).FirstOrDefault();
                if (string.IsNullOrEmpty(port))
                    port = "80";

                return new Response
                {
                    ResponseCode = ResponseCode.RedirectFound,
                    Location = $"http://{host}:{port}/{request.Path}/"
                };
            }

            // Build image galery HTML page
            var path = string.Join(Path.DirectorySeparatorChar, request.Path.Split("/").Skip(2));
            StringBuilder galeryPage = new StringBuilder();
            if (string.IsNullOrEmpty(path))
            {
                var imageList = FindAllImagesInFolder(this.FolderPath);

                galeryPage.AppendLine("<html>");
                
                // html head
                galeryPage.AppendLine("<head>");
                galeryPage.AppendLine("<title>Image Galery</title>");
                galeryPage.AppendLine("</head>");

                //html body
                galeryPage.AppendLine("<body>");

                galeryPage.AppendLine("<div style=\"text-align: center;\">");
                galeryPage.AppendLine("<h1>Image Galery</h1>");
                galeryPage.AppendLine($"<h2>Total images: {imageList.Count()}</h2>");
                galeryPage.AppendLine($"<h2>Total size of images: {imageList.Sum(f => (f as FileInfo).Length )/1024} Kb</h2>");
                galeryPage.AppendLine("</div>");

                galeryPage.AppendLine("<div style=\"float: left;\">");
                foreach (var image in imageList)
                {
                    galeryPage.AppendLine($"<img src=\"{GetHTMLImageSrc(image)}\" height=\"250\" width=\"250\">");
                }
                galeryPage.AppendLine("</div>");

                // end of html body
                galeryPage.AppendLine("</body>");

                // end of html
                galeryPage.AppendLine("</html>");

                return new Response()
                {
                    ResponseCode = ResponseCode.Ok,
                    ContentType = ContentTypes.HtmlText,
                    Body = galeryPage.ToString()
                };
            }

            // Serve the images requested by the image galery HTML page
            path = WebUtility.UrlDecode(path);
            var fullPath = Path.Combine(FolderPath.FullName, path);
            if (!File.Exists(fullPath))
            {
                return new NotFoundResponse();
            }

            var bytes = await File.ReadAllBytesAsync(fullPath);

            return new Response
            {
                Bytes = bytes,
                Type = ResponseType.Binary,
                ContentType = ContentTypes.GetContentType(fullPath)
            };
        }

        public bool IsInterested(Request request, ILogger logger)
        {
            var path = $"galery/{FolderPath.Name}";
            if (request.Path.StartsWith(path, StringComparison.InvariantCultureIgnoreCase))
                return true;

            path = $"galery/{FolderPath.Name}/";
            if (request.Path.StartsWith(path, StringComparison.InvariantCultureIgnoreCase))
                return true;

            return false;
        }
    }
}
