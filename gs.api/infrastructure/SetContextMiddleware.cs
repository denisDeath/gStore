using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace gs.api.infrastructure
{
    public class SetContextMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly CallContext _callContext;

        public SetContextMiddleware([NotNull] RequestDelegate next, [NotNull] CallContext callContext)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _callContext = callContext ?? throw new ArgumentNullException(nameof(callContext));
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Headers.TryGetValue("correlationId", out StringValues corrId))
            {
                _callContext.CorrelationId = Guid.Parse(corrId[0]);
            }
            
            await _next(context);
        }
    }
}