using System;
using System.Net;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;

namespace gs.api.infrastructure
{
    /// <summary>
    /// Заглушка для CORS, обрабатывающая методы OPTIONS.
    /// </summary>
    public class CorsMiddlewareStub
    {
        private readonly RequestDelegate next;

        public CorsMiddlewareStub([NotNull] RequestDelegate next)
        {
            this.next = next ?? throw new ArgumentNullException(nameof(next));
        }

        [UsedImplicitly]
        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Method != HttpMethods.Options)
                await next(context);
            else
            {
                RequestResponseLoggingMiddleware.SetCorsHeaders(context);
                context.Response.StatusCode = (int) HttpStatusCode.OK;
            }
        }
    }
}