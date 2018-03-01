using IeOrganizationDb = gs.api.storage.model.IeOrganization;
using IeUserDb = gs.api.storage.model.User;

using OrganizationSrv = gs.api.contracts.reseller.dto.registration.Organization;
using UserSrv = gs.api.contracts.reseller.dto.registration.User;

namespace gs.api.converters.reseller
{
    public static class ContractsToDb
    {
        public static IeOrganizationDb Convert(this OrganizationSrv source)
        {
            return new IeOrganizationDb
            {
                FullName = source.Name
            };
        }

        public static IeUserDb Convert(this UserSrv source)
        {
            return new IeUserDb
            {
                Email = source.Email,
                Password = source.Password
            };
        }
    }
}