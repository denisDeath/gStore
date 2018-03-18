using System;
using System.Net;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;

namespace gs.api.infrastructure
{
    /// <summary>
    /// Заглушка для CORS, позволяющая любые вызовы.
    /// Нужна, т.к. middleware из пакета Microsoft.AspNetCore.Cors почему-то работает только с методом OPTIONS.
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
            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            context.Response.Headers.Add("Access-Control-Allow-Headers", "*");
            context.Response.Headers.Add("Access-Control-Allow-Methods", "*");

            if (context.Request.Method != HttpMethods.Options)
                await next(context);
            else
            {
                context.Response.StatusCode = (int) HttpStatusCode.OK;
            }
        }
    }
}