using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.dicts.specs
{
    [DataContract]
    public enum SpecificationType
    {
        [EnumMember]
        Bool,
        
        [EnumMember]
        Color,
        
        [EnumMember]
        String,
        
        [EnumMember]
        Number
    }
}