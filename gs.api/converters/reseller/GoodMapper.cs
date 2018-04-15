using System;
using gs.api.contracts.reseller.dto.dicts.goods;
using IeUserDb = gs.api.storage.model.User;
using GoodDb = gs.api.storage.model.resellers.dicts.Good;
using StoreDb = gs.api.storage.model.resellers.dicts.Store;
using OrganizationDb = gs.api.storage.model.Organization;
using UserDb = gs.api.storage.model.User;

namespace gs.api.converters.reseller
{
    public class GoodMapper : IEntityMapper<Good, GoodDb>
    {
        public GoodDb MapToDb(Good source, long ownerId)
        {
            return new GoodDb(ownerId, source.Id, source.Name,
                source.Description,
                String.Join(';', source.ImageUris),
                source.Barcode,
                source.VendorCode,
                source.Unit);
        }
        
        public Good MapToDto(GoodDb source)
        {
            return new Good(source.Id, source.Name,
                source.Description,
                source.ImageUris?.Split(';'),
                source.Barcode,
                source.VendorCode,
                source.Unit);
        }
    }
}