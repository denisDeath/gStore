using System.Collections.Generic;
using System.Runtime.Serialization;
using gs.api.contracts.reseller.dto.dicts.goods;

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