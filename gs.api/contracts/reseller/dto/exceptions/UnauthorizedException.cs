using System;
using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.exceptions
{
    /// <summary>
    /// Исключение, выдаваемое, когда пользователь запросил недоступную ему операцию.
    /// </summary>
    [DataContract]
    public class UnauthorizedException : ApiException
    {
        public UnauthorizedException()
        {
        }

        public UnauthorizedException(string message) : base(message)
        {
        }
    }
}