using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace PracticaFinal.SalasCine.Api.Filters
{
    [AttributeUsage(AttributeTargets.All)]
    public class AppExceptionFilterAttribute:ExceptionFilterAttribute
    {
        private readonly ILogger<AppExceptionFilterAttribute> _logger;

        public AppExceptionFilterAttribute(ILogger<AppExceptionFilterAttribute> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            if (context == null) return;
            _logger.LogError(context.Exception, "{Message}: {Trace}", context.Exception.Message,
                context.Exception.StackTrace);

            var msg = new
            {
                context.Exception.Message,
                ExceptionType = context.Exception.GetType().ToString()
            };

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(msg);
        }
    }
}
