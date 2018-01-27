using System.Collections.Generic;
using gs.api.contracts.suppliers.goods;
using Microsoft.AspNetCore.Mvc;

namespace gs.api.controllers.suppliers.goods
{
    [Route("api/suppliers/goods/list/[action]")]
    public class GoodsController : Controller
    {
        [HttpGet]
        public GetGoodsResponse GetGoods()
        {
            return new GetGoodsResponse(new List<Good>
            {
                new Good(1, "iphone", string.Empty),
                new Good(1, "xiaomi redmi 4x", string.Empty)
            });
        }

        [HttpPut]
        public void AddGoods([FromBody] AddGoodRequest request)
        {
            
        }

        [HttpPost]
        public void RemoveGoods([FromBody] RemoveGoodsRequest request)
        {
            
        }
    }
}