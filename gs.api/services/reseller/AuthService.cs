using System;
using System.Linq;
using System.Text;
using gs.api.contracts.reseller.auth;
using gs.api.contracts.reseller.dto.auth;
using gs.api.contracts.reseller.dto.exceptions;
using gs.api.contracts.reseller.services.interfaces;
using gs.api.storage;
using JetBrains.Annotations;

namespace gs.api.services.reseller
{
    public class AuthService : IAuthService
    {
        private readonly Context Context;
        private const uint TokenExpirationInMinutes = 10;

        public AuthService([NotNull] Context context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public GetAccessTokenResponse GetAccessToken(GetAccessTokenRequest request)
        {
            var user = Context.Users.FirstOrDefault(u =>
                u.PhoneNumber == request.PhoneNumber && u.Password == request.Password);
            if (user == null)
                throw new IncorrectAccessTokenRequestException();

            if (String.IsNullOrWhiteSpace(user.Token)
                || !user.TokenExpireDate.HasValue
                || user.TokenExpireDate >= DateTime.Now)
            {
                // generate new token.
                var newToken = GenerateToken();
                user.Token = newToken.Token;
                user.TokenExpireDate = newToken.Expiration;
                Context.SaveChanges();
            }

            return new GetAccessTokenResponse(user.Token);
        }

        public static (string Token, DateTime Expiration) GenerateToken()
        {
            byte[] bytes = Encoding.UTF8.GetBytes(Guid.NewGuid().ToString());
            string token = Convert.ToBase64String(bytes);
            DateTime expiration = DateTime.UtcNow.AddMinutes(TokenExpirationInMinutes);
            
            return (token, expiration);
        }
    }
}