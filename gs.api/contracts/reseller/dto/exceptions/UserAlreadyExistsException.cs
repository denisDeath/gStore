using System;
using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.exceptions
{
    [DataContract]
    public class UserAlreadyExistsException : Exception
    {
        
    }
}