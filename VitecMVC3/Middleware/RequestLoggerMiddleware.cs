using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace VitecMVC3.Middleware
{
    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly MyFileLoggerOptions options;

        public RequestLoggerMiddleware(RequestDelegate next, IOptions<MyFileLoggerOptions> options) {
            this.next = next;
            this.options = options.Value;
        }
        public async Task Invoke(HttpContext context) {

            var request = context.Request;
            var requestLogMessage = $"REQUEST:\n{request.Method} - {request.Path.Value}{request.QueryString}";
            requestLogMessage += $"\nContentType: {request.ContentType ?? "Not specified"}";
            requestLogMessage += $"\nHost: {request.Host}";
            File.AppendAllText(options.FileName, $"{DateTime.Now.ToString("s")}\n{requestLogMessage}");

            await next(context);

            var response = context.Response;
            var responseLogMessage = $"\nRESPONSE:\nStatus Code: {response.StatusCode}";
            File.AppendAllText(options.FileName, $"{responseLogMessage}\n\n");
        }

    }

    public class MyFileLoggerOptions
    {
        public string FileName { get; set; }
    }
}
