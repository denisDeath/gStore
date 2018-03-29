using System.Runtime.Serialization;

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