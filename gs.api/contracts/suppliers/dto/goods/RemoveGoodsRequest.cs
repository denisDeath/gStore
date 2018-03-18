using System.Collections.Generic;
using System.Runtime.Serialization;

namespace gs.api.contracts.suppliers.goods
{
    [DataContract]
    public class RemoveGoodsRequest : BaseRequest
    {
        public RemoveGoodsRequest(string token, IEnumerable<GoodId> goodsToRemove) : base()
        {
            GoodsToRemove = goodsToRemove;
        }

        [DataMember]
        public IEnumerable<GoodId> GoodsToRemove { get; }
    }
}