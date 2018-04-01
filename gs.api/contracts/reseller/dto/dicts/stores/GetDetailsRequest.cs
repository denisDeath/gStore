using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.dicts.stores
{
    [DataContract]
    public class GetDetailsRequest
    {
        public GetDetailsRequest(long id)
        {
            Id = id;
        }

        [DataMember(IsRequired = true)]
        public long Id { get; set; }
    }
}