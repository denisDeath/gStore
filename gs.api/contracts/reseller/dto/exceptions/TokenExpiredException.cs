using System;
using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.exceptions
{
    /// <summary>
    /// Исключение, говорящее, что переданный токен устарел и его необходимо перегенерировать.
    /// </summary>
    [DataContract]
    public class TokenExpiredException : Exception
    {
        
    }
}