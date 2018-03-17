using gs.api.contracts.reseller.dto.auth;
using gs.api.contracts.reseller.dto.exceptions;

namespace gs.api.contracts.reseller.services.interfaces
{
    /// <summary>
    /// Методы аутентификации пользователя.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Запрос на получение токена.
        /// </summary>
        [Throws(typeof(IncorrectAccessTokenRequestException))]
        GetAccessTokenResponse GetAccessToken(GetAccessTokenRequest request);
    }
}