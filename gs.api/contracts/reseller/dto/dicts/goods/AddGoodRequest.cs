using System.Runtime.Serialization;
using gs.api.contracts.reseller.dto.dicts.goods;

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