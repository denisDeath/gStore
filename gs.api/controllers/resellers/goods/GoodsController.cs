using System;
using gs.api.auth;
using gs.api.contracts.reseller.dto.goods;
using gs.api.contracts.reseller.services.interfaces;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gs.api.controllers.resellers.goods
{
    [Route("api/resellers/goods/list/[action]")]
    [Authorize(Roles = Roles.ResellerAdmin)]
    public class GoodsController : Controller
    {
        private readonly IGoodsService GoodsService;

        public GoodsController([NotNull] IGoodsService goodsService)
        {
            GoodsService = goodsService ?? throw new ArgumentNullException(nameof(goodsService));
        }

        [HttpPost]
        public GetGoodsResponse GetGoods()
        {
            return GoodsService.GetGoods();
        }

        [HttpPost]
        public AddGoodResponse AddGood([NotNull] [FromBody] AddGoodRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            return GoodsService.AddGood(request);
        }

        [HttpPost]
        public void RemoveGoods([NotNull] [FromBody] RemoveGoodsRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            GoodsService.RemoveGoods(request);
        }
        
        [HttpPost]
        public void SaveGoodDetails([NotNull] [FromBody] SaveGoodDetailsRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            GoodsService.SaveGoodDetails(request);
        }

        [HttpPost]
        public GetGoodDetailsResponse GetGoodDetails([NotNull] [FromBody] GetGoodDetailsRequest request)
        {
            return GoodsService.GetGoodDetails(request);
        }
    }
}