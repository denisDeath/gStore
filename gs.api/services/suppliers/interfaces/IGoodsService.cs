using System.Collections.Generic;
using gs.api.contracts.suppliers.goods;

namespace gs.api.services.suppliers.interfaces
{
    public interface IGoodsService
    {
        GetGoodsResponse GetGoods();
    }
}