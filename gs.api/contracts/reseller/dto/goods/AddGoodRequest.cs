using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.goods
{
    [DataContract]
    public class AddGoodRequest : BaseRequest
    {
        public AddGoodRequest(Good goodToAdd)
        {
            GoodToAdd = goodToAdd;
        }

        [DataMember(IsRequired = true)]
        public Good GoodToAdd { get; }
    }
}