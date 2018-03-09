using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;

namespace gs.api.infrastructure
{
    /// <summary>
    /// Вспомогательный класс для работы с HttpContext.
    /// </summary>
    public static class HttpContextHelper
    {
        /// <summary>
        /// Получить тело http-запроса.
        /// </summary>
        internal static async Task<string> GetRequestBody(this HttpContext context)
        {
            var injectedRequestStream = new MemoryStream();
            using (var bodyReader = new StreamReader(context.Request.Body))
            {
                var requestBodyString = await bodyReader.ReadToEndAsync();
                var bytesToWrite = Encoding.UTF8.GetBytes(requestBodyString);
                await injectedRequestStream.WriteAsync(bytesToWrite, 0, bytesToWrite.Length);
                injectedRequestStream.Seek(0, SeekOrigin.Begin);
                context.Request.Body = injectedRequestStream;
                return requestBodyString;
            }
        }

        /// <summary>
        /// Получить тело http-ответа. Внутри метода происходит вызов <code>next()</code> для передачи запроса далее по конвееру.
        /// </summary>
        internal static async Task<string> GetResponseBody(this HttpContext context, RequestDelegate next)
        {
            //Если статус ответа 204(NoContent), то нельзя пытаться что-либо писать в ответ. Получим ошибку вида
            //System.InvalidOperationException: Writing to the response body is invalid for responses with status code 204.
            if (context.Response.StatusCode == (int)HttpStatusCode.NoContent)
            {
                return null;
            }
            var originalBodyStream = context.Response.Body;
            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;
                try
                {
                    await next(context);
                    //Если статус ответа 204(NoContent), то нельзя пытаться что-либо писать в ответ. Получим ошибку вида
                    //System.InvalidOperationException: Writing to the response body is invalid for responses with status code 204.
                    if (context.Response.StatusCode == (int)HttpStatusCode.NoContent)
                    {
                        return null;
                    }
                }
                catch
                {
                    context.Response.Body = originalBodyStream;
                    throw;
                }
                
                context.Response.Body.Seek(0, SeekOrigin.Begin);
                var streamReader = new StreamReader(context.Response.Body);
                var responseBodyString = await streamReader.ReadToEndAsync();
                context.Response.Body.Seek(0, SeekOrigin.Begin);
                await responseBody.CopyToAsync(originalBodyStream);
                return responseBodyString;
            }
        }
    }
}