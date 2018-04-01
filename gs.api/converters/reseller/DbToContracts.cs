using Good = gs.api.contracts.reseller.dto.dicts.goods.Good;
using Store = gs.api.contracts.reseller.dto.dicts.stores.Store;

using GoodDb = gs.api.storage.model.resellers.dicts.Good;
using StoreDb = gs.api.storage.model.resellers.dicts.Store;

namespace gs.api.converters.reseller
{
    public static class DbToContracts
    {
        public static Good ConvertToGood(this GoodDb source)
        {
            return new Good(source.Id, source.Name,
                source.Description,
                source.ImageUris?.Split(';'),
                source.Barcode,
                source.VendorCode,
                source.Unit);
        }
        
        public static Store ConvertToStore(this StoreDb source)
        {
            return new Store(source.Id, source.Name, source.Description, source.Address, source.IsShop);
        }
    }
}