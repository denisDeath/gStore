using gs.api.contracts.reseller;
using gs.api.contracts.reseller.dto.registration;
using gs.api.contracts.reseller.services.interfaces;
using gs.api.converters.reseller;
using gs.api.storage.repositories.interfaces;

namespace gs.api.services.reseller
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IOrganizationsRepository OrganizationsRepository;

        public RegistrationService(IOrganizationsRepository organizationsRepository)
        {
            OrganizationsRepository = organizationsRepository;
        }

        public RegisterOrganizationResponse RegisterOrganization(RegisterOrganizationRequest request)
        {
            OrganizationsRepository.AddOrganization(request.Organization.Convert());
            return new RegisterOrganizationResponse("666");
        }

        public bool IsOrganizationNameExists(IsOrganizationNameExistsRequest request)
        {
            throw new System.NotImplementedException();
        }

        public bool IsUserEmailExists(IsUserEmailExistsRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}