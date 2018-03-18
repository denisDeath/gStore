using System.Collections.Generic;
using System.Runtime.Serialization;

namespace gs.api.contracts.suppliers.goods
{
    [DataContract]
    public class AddGoodRequest : BaseRequest
    {
        public AddGoodRequest(string token, IEnumerable<Good> goodsToAdd) : base()
        {
            GoodsToAdd = goodsToAdd;
        }

        [DataMember]
        public IEnumerable<Good> GoodsToAdd { get; }
    }
}