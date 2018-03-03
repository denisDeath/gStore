using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.registration
{
    [DataContract]
    public class RegisterOrganizationRequest
    {
        public RegisterOrganizationRequest(string userPhoneNumber, string password, string organizationTrademark)
        {
            UserPhoneNumber = userPhoneNumber;
            Password = password;
            OrganizationTrademark = organizationTrademark;
        }

        [DataMember(IsRequired = true)]
        public string UserPhoneNumber { get; }
        
        [DataMember(IsRequired = true)]
        public string Password { get; }
        
        [DataMember(IsRequired = true)]
        public string OrganizationTrademark { get; }
    }
}