using gs.api.contracts.reseller.dto.registration;
using Good = gs.api.contracts.reseller.dto.dicts.goods.Good;
using Store = gs.api.contracts.reseller.dto.dicts.stores.Store;

using GoodDb = gs.api.storage.model.resellers.dicts.Good;
using StoreDb = gs.api.storage.model.resellers.dicts.Store;
using OrganizationDb = gs.api.storage.model.Organization;
using UserDb = gs.api.storage.model.User;

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

        public static OrganizationSettings ConvertToOrganizationSettings(OrganizationDb organization, UserDb user)
        {
            return new OrganizationSettings(
                ownerFirstName: user.FirstName,
                ownerLastName: user.LastName,
                ownerPatronymic: user.Patronymic,
                tradeMark: organization.TradeMark,
                fullName: organization.FullName,
                address: organization.Address,
                phone: organization.Phone,
                inn: organization.Inn,
                useVat: organization.UseVat
                );
        }
    }
}