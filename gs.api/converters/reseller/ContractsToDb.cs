using OrganizationDb = gs.api.storage.model.Organization;
using OrganizationSrv = gs.api.contracts.reseller.dto.registration.Organization;

namespace gs.api.converters.reseller
{
    public static class ContractsToDb
    {
        public static OrganizationDb Convert(this OrganizationSrv source)
        {
            return new OrganizationDb(0, source.Name);
        }
        
    }
}