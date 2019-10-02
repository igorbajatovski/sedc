using ServerInterfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ServerCore.Responses
{
    public class FaviconResponseGenerator : IResponseGenerator
    {
        public int Count => throw new NotImplementedException();

        public Task<Response> Generate(Request request, ILogger logger)
        {   
            //var faviconBytes = File.ReadAllBytes(@"D:\MATERIJALI_KNIGI\Seavus education\Classes\Zadaci+Domasno\Repo\sedc7-11-3-csserver\SedcServer\ServerRunner\search.png");
            var faviconBytes = File.ReadAllBytes($@"{Environment.CurrentDirectory}{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}search.png");
            
            return Task.Run<Response>(() =>
           {
               return new Response()
               {
                   ContentType = ContentTypes.GetContentType("search.png"),
                   Type = ResponseType.Binary,
                   Bytes = faviconBytes
               };
           });
        }

        public bool IsInterested(Request request, ILogger logger)
        {
            if (request.Path.Equals("favicon.ico"))
                return true;
            return false;
        }
    }
}
