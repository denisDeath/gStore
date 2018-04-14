using System.Runtime.Serialization;
using gs.api.contracts.reseller.dto.dicts.goods;

namespace gs.api.contracts.reseller.dto.goods
{
    [DataContract]
    public class GetEntityDetailsResponse<T>
    {
        public GetEntityDetailsResponse(T entityDetails)
        {
            EntityDetails = entityDetails;
        }

        [DataMember(IsRequired = true)]
        public T EntityDetails { get; set; }
    }
}