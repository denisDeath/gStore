using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace gs.api.contracts.reseller.dto.exceptions
{
    /// <summary>
    /// Исключение, говорящее, что переданный токен устарел и его необходимо перегенерировать.
    /// </summary>
    [DataContract]
    public class TokenExpiredException : ApiException
    {
        public const string DefaultMessage = "Переданный токен устарел и его необходимо перегенерировать.";

        public TokenExpiredException([CanBeNull] string message = null) : base(message ?? DefaultMessage)
        {
        }
    }
}