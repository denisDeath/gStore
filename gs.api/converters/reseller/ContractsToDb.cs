using System;
using gs.api.contracts.reseller.dto.goods;
using gs.api.contracts.reseller.dto.registration;
using OrganizationDb = gs.api.storage.model.Organization;
using IeUserDb = gs.api.storage.model.User;
using GoodDb = gs.api.storage.model.resellers.goods.Good;

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
    }
}