using System;
using System.Linq;
using gs.api.contracts.reseller.dto.dicts.stores;
using gs.api.contracts.reseller.dto.goods;
using gs.api.contracts.reseller.services.interfaces.dicts;
using gs.api.converters.reseller;
using gs.api.infrastructure;
using gs.api.storage;
using JetBrains.Annotations;

namespace gs.api.services.reseller.dicts
{
    public class StoresService : IStoresService
    {
        [NotNull] private readonly Context _context;
        [NotNull] private readonly CallContext _callContext;

        public StoresService([NotNull] Context context, [NotNull] CallContext callContext)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _callContext = callContext ?? throw new ArgumentNullException(nameof(callContext));
        }

        public GetResponse Get()
        {
            var goods = _context.Stores
                .Where(g => g.Owner.OrganizationId == _callContext.CurrentOrganizationId)
                .ToList();
            return new GetResponse(goods.Select(DbToContracts.ConvertToStore));
        }
        
        public AddResponse Add(AddRequest request)
        {
            var newItem = ContractsToDb.ConvertToStore(request.Store, _callContext.CurrentOrganizationId);
            _context.Stores.Add(newItem);
            _context.SaveChanges();
            return new AddResponse(newItem.Id);
        }

        public void Remove([NotNull] RemoveRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            
            // TODO: чтобы удалить сущность, мы вытягиваем её из БД.
            var goodToRemove = _context.Stores
                .FirstOrDefault(g => g.Id == request.StoreId 
                                     && g.Owner.OrganizationId == _callContext.CurrentOrganizationId);
            if (goodToRemove != null)
                _context.Remove(goodToRemove);
            _context.SaveChanges();
        }

        public void SaveDetails([NotNull] SaveDetailsRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var goodFromDb = _context.Stores
                .FirstOrDefault(g => g.Id == request.Store.Id
                                     && g.Owner.OrganizationId == _callContext.CurrentOrganizationId);
            if (goodFromDb == null)
                throw new InvalidOperationException($" with id {request.Store.Id} not found.");

            var changedDb = request.Store.ConvertToStore(_callContext.CurrentOrganizationId);
            goodFromDb.UpdateFieldsFrom(changedDb);
            _context.SaveChanges();
        }

        public GetDetailsResponse GetDetails([NotNull] GetDetailsRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            var good = _context.Stores.FirstOrDefault(g => g.Id == request.Id);
            if (good == null)
                throw new Exception($" with id {request.Id} not found.");
            
            return new GetDetailsResponse(good.ConvertToStore());
        }
    }
}