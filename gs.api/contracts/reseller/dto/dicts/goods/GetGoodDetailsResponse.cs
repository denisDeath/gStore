using System.Runtime.Serialization;
using gs.api.contracts.reseller.dto.dicts.goods;

namespace gs.api.contracts.reseller.dto.goods
{
    [DataContract]
    public class GetGoodDetailsResponse
    {
        public GetGoodDetailsResponse(Good goodDetails)
        {
            GoodDetails = goodDetails;
        }

        [DataMember(IsRequired = true)]
        public Good GoodDetails { get; set; }
    }
}