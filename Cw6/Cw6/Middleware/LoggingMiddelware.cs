using Cw6.Models;
using Cw6.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Cw6.Middleware
{
    public class LoggingMiddelware
    {
        private readonly RequestDelegate _next;
        private ILoggerService _logService;

        public LoggingMiddelware(RequestDelegate next)
        {
            _next = next;
            
        }

        public async Task InvokeAsync(HttpContext context, ILoggerService logService)
        {
            _logService = logService;

            context.Request.EnableBuffering();

            if (context.Request != null)
            {
                Log requestLog = new Log();

                requestLog.TimeStamp = DateTime.Now.ToString();
                requestLog.Method = context.Request.Method;
                requestLog.Path = context.Request.Path;
                requestLog.QueryString = context.Request.QueryString.ToString();

                using (var reader = new StreamReader(
                    context.Request.Body,
                    Encoding.UTF8,
                    true,
                    1024,
                    true))
                {
                    requestLog.Body = await reader.ReadToEndAsync();
                    context.Request.Body.Position = 0;
                    
                }

                _logService.Log(requestLog);
            }

            await _next(context);
        }
    }
}
