using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.goods
{
    [DataContract]
    public class GetGoodDetailsRequest
    {
        public GetGoodDetailsRequest(long goodId)
        {
            GoodId = goodId;
        }

        [DataMember(IsRequired = true)]
        public long GoodId { get; set; }
    }
}