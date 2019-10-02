using ServerInterfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ServerPlugins
{
    public class HTMLSizePostProcessor : IResponsePostProcessor
    {

        public bool IsInterested(Response response, ILogger logger)
        {
            return (response.ResponseCode == ResponseCode.Ok && response.ContentType == ContentTypes.HtmlText);
        }

        public async Task<Response> Process(Response response, ILogger logger)
        {
            if (response.Bytes != null)
            {
                StringBuilder sb = new StringBuilder(Encoding.UTF8.GetString(response.Bytes));
                string size = $"{response.Bytes.Length / 1024} Kb";
                sb.Replace("</body>", $"<div style=\"color: red; position: fixed; bottom: 10px;\">Size of HTML page is {size}</div></body>");
                response.Bytes = Encoding.UTF8.GetBytes(sb.ToString());
                return response;
            }
            return response;
        }
    }
}
