using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace gs.api.contracts.reseller
{
    [DataContract]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UserRole
    {
        /// <summary>
        /// Владелец организации-реселлера.
        /// </summary>
        [EnumMember]
        Owner,
        
        /// <summary>
        /// Продавец.
        /// </summary>
        [EnumMember]
        Seller
    }
}