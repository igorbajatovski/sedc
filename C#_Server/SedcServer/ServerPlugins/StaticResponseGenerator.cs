using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ServerInterfaces;

namespace ServerPlugins
{
    public class StaticResponseGenerator : IResponseGenerator
    {
        public int Count { get; }
        public string FolderName { get; private set; }
        public string FolderPath { get; private set; }

        public StaticResponseGenerator (string folderName)
        {
            FolderName = Path.GetFileName(folderName);
            FolderPath = Path.GetFullPath(folderName);
        }

        public async Task<Response> Generate(Request request, ILogger logger)
        {
            var defaultIndexPages = new string[] { "index.html", "index.htm", "default.html", "default.htm" };
            var path = string.Join(Path.DirectorySeparatorChar, request.Path.Split("/").Skip(2));
            
            if(string.IsNullOrEmpty(path))
            {
                foreach(var indexPage in defaultIndexPages)
                {
                    var indexPath = Path.Combine(FolderPath, indexPage);
                    if (!File.Exists(indexPath))
                        return new NotFoundResponse();
                    else
                    {
                        path = indexPage;
                        break;
                    }
                }

                // Rederect the default URL to defult URL/index.html
                var host = request.Headers.GetHeader("Host").Split(":").First();
                var port = request.Headers.GetHeader("Host").Split(":").Skip(1).FirstOrDefault();
                if (string.IsNullOrEmpty(port))
                    port = "80";

                return new Response
                {
                    ResponseCode = ResponseCode.RedirectFound,
                    Location = $"http://{host}:{port}/{request.Path}/{path}"
                };
            }

            var fullPath = Path.Combine(FolderPath, path);
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
            var path = $"static/{FolderName}";
            if (request.Path.StartsWith(path, StringComparison.InvariantCultureIgnoreCase))
                return true;

            path = $"static/{FolderName}/";
            if (request.Path.StartsWith(path, StringComparison.InvariantCultureIgnoreCase))
                return true;

            return false;
        }
    }
}
