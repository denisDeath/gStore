using System;
using System.Linq;
using gs.api.contracts.reseller.dto.goods;
using gs.api.contracts.reseller.services.interfaces.dicts;
using gs.api.converters.reseller;
using gs.api.infrastructure;
using gs.api.storage;
using JetBrains.Annotations;

namespace gs.api.services.reseller.dicts
{
    public class GoodsService : IGoodsService
    {
        [NotNull] private readonly Context _context;
        [NotNull] private readonly CallContext _callContext;

        public GoodsService([NotNull] Context context, [NotNull] CallContext callContext)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _callContext = callContext ?? throw new ArgumentNullException(nameof(callContext));
        }

        public GetGoodsResponse GetGoods()
        {
            var goods = _context.Goods
                .Where(g => g.Owner.OrganizationId == _callContext.CurrentOrganizationId)
                .ToList();
            return new GetGoodsResponse(goods.Select(DbToContracts.ConvertToGood));
        }

        public AddGoodResponse AddGood(AddGoodRequest request)
        {
            var newGood = ContractsToDb.ConvertToGood(request.GoodToAdd, _callContext.CurrentOrganizationId);
            _context.Goods.Add(newGood);
            _context.SaveChanges();
            return new AddGoodResponse(newGood.Id);
        }

        public void RemoveGoods([NotNull] RemoveGoodsRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            
            // чтобы удалить сущность, мы вытягиваем её из БД.
            // TODO: надо просто удалять по идентификатору/ам без лишних накладных расходов.
            foreach (long idToRemove in request.IdsToRemove)
            {
                var goodToRemove = _context.Goods
                    .FirstOrDefault(g => g.Id == idToRemove 
                                         && g.Owner.OrganizationId == _callContext.CurrentOrganizationId);
                if (goodToRemove != null)
                    _context.Remove(goodToRemove);
            }
            _context.SaveChanges();
        }

        public void SaveGoodDetails([NotNull] SaveGoodDetailsRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var goodFromDb = _context.Goods
                .FirstOrDefault(g => g.Id == request.Good.Id
                                     && g.Owner.OrganizationId == _callContext.CurrentOrganizationId);
            if (goodFromDb == null)
                throw new InvalidOperationException($"Good with id {request.Good.Id} not found.");

            var changedDbGood = request.Good.ConvertToGood(_callContext.CurrentOrganizationId);
            goodFromDb.UpdateFieldsFrom(changedDbGood);
            _context.SaveChanges();
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