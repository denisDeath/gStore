using System;
using gs.api.contracts.reseller.dto.dicts.goods;
using gs.api.contracts.reseller.dto.dicts.stores;
using gs.api.contracts.reseller.dto.registration;
using IeUserDb = gs.api.storage.model.User;
using GoodDb = gs.api.storage.model.resellers.dicts.Good;
using StoreDb = gs.api.storage.model.resellers.dicts.Store;
using OrganizationDb = gs.api.storage.model.Organization;
using UserDb = gs.api.storage.model.User;

namespace gs.api.converters.reseller
{
    public static class ContractsToDb
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

        public static GoodDb ConvertToGood(this Good source, long ownerId)
        {
            return new GoodDb(ownerId, source.Id, source.Name,
                source.Description,
                String.Join(';', source.ImageUris),
                source.Barcode,
                source.VendorCode,
                source.Unit);
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
    }
}