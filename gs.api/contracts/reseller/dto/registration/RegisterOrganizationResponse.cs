using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.registration
{
    [DataContract]
    public class RegisterOrganizationResponse
    {
        public RegisterOrganizationResponse(string phoneNumber, string token)
        {
            PhoneNumber = phoneNumber;
            Token = token;
        }

        [DataMember(IsRequired = true)]
        public string PhoneNumber { get; }
        
        [DataMember(IsRequired = true)]
        public string Token { get; }
    }
}