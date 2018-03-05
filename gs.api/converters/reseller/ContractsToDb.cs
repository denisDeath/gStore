using gs.api.contracts.reseller.dto.registration;
using IeOrganizationDb = gs.api.storage.model.IeOrganization;
using IeUserDb = gs.api.storage.model.User;

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
    }
}