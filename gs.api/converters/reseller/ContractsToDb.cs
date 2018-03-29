using System;
using gs.api.contracts.reseller.dto.goods;
using gs.api.contracts.reseller.dto.registration;
using IeOrganizationDb = gs.api.storage.model.IeOrganization;
using IeUserDb = gs.api.storage.model.User;
using GoodDb = gs.api.storage.model.resellers.goods.Good;

namespace gs.api.converters.reseller
{
    public static class ContractsToDb
    {
        public static IeOrganizationDb ConvertToOrganization(this RegisterOrganizationRequest source)
        {
            return new IeOrganizationDb();
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

        public static GoodDb ConvertToGood(this Good source)
        {
            return new GoodDb(source.Id, source.Name,
                source.Description,
                String.Join(';', source.ImageUris),
                source.Barcode,
                source.VendorCode,
                source.Unit);
        }
    }
}