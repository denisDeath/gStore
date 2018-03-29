using System;
using System.Linq;
using gs.api.contracts.reseller.dto.goods;
using gs.api.contracts.reseller.services.interfaces;
using gs.api.converters.reseller;
using gs.api.storage;
using JetBrains.Annotations;

namespace gs.api.services.reseller
{
    public class GoodsService : IGoodsService
    {
        [NotNull] private readonly Context _context;

        public GoodsService([NotNull] Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public GetGoodsResponse GetGoods()
        {
            var goods = _context.Goods.ToList();
            return new GetGoodsResponse(goods.Select(DbToContracts.ConvertToGood));
        }

        public AddGoodResponse AddGood(AddGoodRequest request)
        {
            var newGood = request.GoodToAdd.ConvertToGood();
            _context.Goods.Add(newGood);
            _context.SaveChanges();
            return new AddGoodResponse(newGood.Id);
        }

        public void RemoveGoods([NotNull] RemoveGoodsRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            var goodsToRemove = _context.Goods.Where(g => request.IdsToRemove.Any(id => id == g.Id));
            _context.RemoveRange(goodsToRemove);
        }

        public void SaveGoodDetails(SaveGoodDetailsRequest request)
        {
            throw new System.NotImplementedException();
        }

        public GetGoodDetailsResponse GetGoodDetails([NotNull] GetGoodDetailsRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            var good = _context.Goods.FirstOrDefault(g => g.Id == request.GoodId);
            if (good == null)
                throw new Exception($"Good with id {request.GoodId} not found.");
            
            return new GetGoodDetailsResponse(good.ConvertToGood());
        }
    }
}