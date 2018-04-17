using gs.api.contracts.reseller.dto.dicts.stores;
using IeUserDb = gs.api.storage.model.User;
using GoodDb = gs.api.storage.model.resellers.dicts.Good;
using StoreDb = gs.api.storage.model.resellers.dicts.Store;
using OrganizationDb = gs.api.storage.model.Organization;
using UserDb = gs.api.storage.model.User;

namespace gs.api.converters.reseller
{
    public class StoreMapper : IEntityMapper<Store, StoreDb>
    {
        public StoreDb MapToDb(Store source, long ownerId)
        {
            return new StoreDb(ownerId, source.Id, source.Name, source.Description, source.Address, source.IsShop);
        }
        public Store MapToDto(StoreDb source)
        {
            return new Store(source.Id, source.Name, source.Description, source.Address, source.IsShop);
        }
    }
}