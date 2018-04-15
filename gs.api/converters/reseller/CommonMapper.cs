using gs.api.contracts.reseller.dto.dicts.stores;
using gs.api.contracts.reseller.dto.registration;
using IeUserDb = gs.api.storage.model.User;
using GoodDb = gs.api.storage.model.resellers.dicts.Good;
using StoreDb = gs.api.storage.model.resellers.dicts.Store;
using OrganizationDb = gs.api.storage.model.Organization;
using UserDb = gs.api.storage.model.User;

namespace gs.api.converters.reseller
{
    public static class CommonMapper
    {
        public static OrganizationDb ConvertToOrganization(this RegisterOrganizationRequest source)
        {
            return new OrganizationDb();
        }

        public static IeUserDb ConvertToUser(this RegisterOrganizationRequest source)
        {
            return new IeUserDb
            {
                FirstName = source.FirstName,
                LastName = source.Lastame,
                Patronymic = source.Patronymic,
                PhoneNumber = source.UserPhoneNumber,
                Password = source.Password
            };
        }
        
        public static StoreDb ConvertToStore(this Store source, long ownerId)
        {
            return new StoreDb(ownerId, source.Id, source.Name, source.Description, source.Address, source.IsShop);
        }

        public static (UserDb User, OrganizationDb Organization) ConvertToContracts(this OrganizationSettings source)
        {
            var organization = new OrganizationDb
            {
                TradeMark = source.TradeMark,
                FullName = source.FullName,
                Address = source.Address,
                Phone = source.Phone,
                Inn = source.Inn,
                UseVat = source.UseVat
            };

            var user = new UserDb
            {
                FirstName = source.OwnerFirstName,
                LastName = source.OwnerLastName,
                Patronymic = source.OwnerPatronymic
            };
            
            return (user, organization);
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