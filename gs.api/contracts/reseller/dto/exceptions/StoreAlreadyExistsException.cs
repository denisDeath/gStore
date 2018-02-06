using System;
using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.exceptions
{
    /// <summary>
    /// Исключение, говорящее, что магазин с указанным именем уже существует.
    /// </summary>
    [DataContract]
    public class StoreAlreadyExistsException : Exception
    {
        
    }
}