using System.Collections.Generic;
using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.goods
{
    [DataContract]
    public class GetGoodsResponse
    {
        public GetGoodsResponse(IEnumerable<Good> goods)
        {
            Goods = goods;
        }

        [DataMember]
        public IEnumerable<Good> Goods { get; }
    }
}