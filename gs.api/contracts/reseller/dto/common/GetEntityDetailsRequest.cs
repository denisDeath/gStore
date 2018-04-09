using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.goods
{
    [DataContract]
    public class GetEntityDetailsRequest
    {
        [DataMember(IsRequired = true)]
        public long EntityId { get; set; }
    }
}