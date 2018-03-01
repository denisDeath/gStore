using System;
using System.Collections.Generic;
using gs.api.contracts.suppliers.goods;
using gs.api.services.suppliers.interfaces;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;

namespace gs.api.controllers.suppliers.goods
{
    [Route("api/suppliers/goods/list/[action]")]
    public class GoodsController : Controller
    {
        private readonly IGoodsService GoodsService;

        public GoodsController([NotNull] IGoodsService goodsService)
        {
            GoodsService = goodsService ?? throw new ArgumentNullException(nameof(goodsService));
        }

        [HttpGet]
        public GetGoodsResponse GetGoods()
        {
            return GoodsService.GetGoods();
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