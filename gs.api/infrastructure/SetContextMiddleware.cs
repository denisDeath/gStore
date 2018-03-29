using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using gs.api.contracts.reseller.dto.exceptions;
using gs.api.storage;
using gs.api.storage.model;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace gs.api.infrastructure
{
    public class SetContextMiddleware
    {
        private readonly RequestDelegate _next;

        public SetContextMiddleware([NotNull] RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke([NotNull] HttpContext context, 
            [NotNull] CallContext sessionContext,
            [NotNull] Context dbContext)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (sessionContext == null) throw new ArgumentNullException(nameof(sessionContext));
            if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));

            // set correlation id.
            Guid correlationId;
            if (context.Request.Headers.TryGetValue("correlationId", out StringValues corrId))
                correlationId = Guid.Parse(corrId[0]);

            // set current organization and user.
            var currentOrganization = new Lazy<(Organization, User)>(() => GetCurrentOrganization(context, dbContext));

            sessionContext.Initialize(correlationId, dbContext, currentOrganization);
            await _next(context);
        }
        
        private (Organization Organization, User User) GetCurrentOrganization(HttpContext context, Context dbContext)
        {
            Claim currentPhoneClaim =
                context.User.Claims.FirstOrDefault(c => c.Type == ClaimsIdentity.DefaultNameClaimType);
            if (currentPhoneClaim == null)
                throw new UnauthorizedException();
            
            var user = dbContext.Users.FirstOrDefault(u => u.PhoneNumber == currentPhoneClaim.Value);
            if (user == null)
                throw new UnauthorizedException();

            var organization = dbContext.Organizations.FirstOrDefault(o => o.Owner.UserId == user.UserId);
            if (organization == null)
                throw new InvalidOperationException($"User with id {user.UserId} not owns any organization.");
            return (organization, user);
        }
    }
}