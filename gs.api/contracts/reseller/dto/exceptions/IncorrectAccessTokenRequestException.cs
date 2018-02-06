using System;
using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.exceptions
{
    /// <summary>
    /// Исключение, выдаваемое при неверных данных запроса пользовательского токена.
    /// </summary>
    [DataContract]
    public class IncorrectAccessTokenRequestException : Exception
    {
        
    }
}