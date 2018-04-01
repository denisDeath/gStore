using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.dicts.stores
{
    [DataContract]
    public class GetDetailsResponse
    {
        public GetDetailsResponse(Store details)
        {
            Store = details;
        }

        [DataMember(IsRequired = true)]
        public Store Store { get; set; }
    }
}