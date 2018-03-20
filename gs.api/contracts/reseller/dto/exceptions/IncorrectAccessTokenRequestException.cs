using System.Net;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace gs.api.contracts.reseller.dto.exceptions
{
    /// <summary>
    /// Исключение, выдаваемое при неверных данных запроса пользовательского токена.
    /// </summary>
    [DataContract]
    public class IncorrectAccessTokenRequestException : ApiException
    {
        public const string DefaultMessage = "Incorrect credentials were passed to get token.";

        public IncorrectAccessTokenRequestException([CanBeNull] string message = null) 
            : base(message ?? DefaultMessage, HttpStatusCode.BadRequest)
        {
        }
    }
}