using System.Runtime.Serialization;

namespace gs.api.contracts.reseller
{
    [DataContract]
    public class RegisterOrganizationResponse
    {
        public RegisterOrganizationResponse(string token)
        {
            Token = token;
        }

        [DataMember(IsRequired = true)]
        public string Token { get; }
    }
}