using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using gs.api.contracts;
using gs.api.infrastructure.logging;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;

namespace gs.api.infrastructure
{
    /// <summary>
    /// Класс, логирующий информацию о запросах и результатах выполнения методов действия (в том числе логирование исключений).
    /// </summary>
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILog _log;

        public RequestResponseLoggingMiddleware([NotNull] RequestDelegate next, [NotNull] ILog log)
        {
            this.next = next ?? throw new ArgumentNullException(nameof(next));
            _log = log ?? throw new ArgumentNullException(nameof(log));
        }

        [UsedImplicitly]
        public async Task Invoke(HttpContext context)
        {
            var requestString = await context.GetRequestBody();
            string requestHeaders = GetHeaders(context.Request.Headers);
            _log.LogDebug(context.Request.Path, $"Executing action by uri {context.Request.Path}. " +
                                $"Method: {context.Request.Method}. " +
                                $"Headers: {requestHeaders}. " +
                                $"Request:{requestString}.");
            try
            {
                var responseString = await context.GetResponseBody(next);
                string responseHeaders = GetHeaders(context.Response.Headers);
                var message = $"Action by uri {context.Request.Path} executed. " +
                              $"Code: {context.Response.StatusCode}. " +
                              $"Headers: {responseHeaders}. " +
                              $"Response:{responseString}";
                _log.LogDebug(context.Request.Path, message);
            }
            catch (Exception exc)
            {
                context.Response.Clear();
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
//                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                if (exc is ApiException)
                {
                    context.Response.Headers.Add(ApiException.ApiExceptionHeaderSign, exc.GetType().FullName);

                    var exceptionInfo = new
                    {
                        exceptionType = exc.GetType().Name,
                        message = exc.Message
                    };
                    
                    await context.Response.WriteAsync(exceptionInfo.ToJson());
                }
                
                _log.LogError($"Error executing action by uri {context.Request.Path}: {exc.Message}", exc);
            }
        }

        #region private

        private string GetHeaders(IHeaderDictionary heeaderDictionary)
        {
            IEnumerable<string> headersValues = heeaderDictionary.Select(h => $"{h.Key}: {h.Value.ToString()}");
            return String.Join(",", headersValues);
        }
        
        #endregion
    }
}