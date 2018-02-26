using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.registration
{
    [DataContract]
    public class RegisterOrganizationRequest
    {
        public RegisterOrganizationRequest(Organization organization, User owner)
        {
            Organization = organization;
            Owner = owner;
        }

        [DataMember(IsRequired = true)]
        public Organization Organization { get; }
        
        [DataMember(IsRequired = true)]
        public User Owner { get; }
    }
}