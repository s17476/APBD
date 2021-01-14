using Cw6.Exceptions;
using Cw6.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Cw6.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception exc)
            {
                await HandleExceptionAsync(context, exc);
            }

        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception exc)
        {
            httpContext.Response.ContentType = "application/json";

            var responseCode = StatusCodes.Status400BadRequest;

            if (exc is NotFoundException)
                responseCode = StatusCodes.Status404NotFound;

            httpContext.Response.StatusCode = responseCode;

            return httpContext.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = exc.Message
            }.ToString());
        }
    }
}
