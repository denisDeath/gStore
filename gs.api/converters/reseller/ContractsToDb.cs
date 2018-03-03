using gs.api.contracts.reseller.dto.registration;
using IeOrganizationDb = gs.api.storage.model.IeOrganization;
using IeUserDb = gs.api.storage.model.User;

namespace gs.api.converters.reseller
{
    public static class ContractsToDb
    {
        public static IeOrganizationDb ConvertToOrganization(this RegisterOrganizationRequest source)
        {
            return new IeOrganizationDb
            {
                TradeMark = source.OrganizationTrademark
            };
        }

        public static IeUserDb ConvertToUser(this RegisterOrganizationRequest source)
        {
            return new IeUserDb
            {
                PhoneNumber = source.UserPhoneNumber,
                Password = source.Password
            };
        }
    }
}