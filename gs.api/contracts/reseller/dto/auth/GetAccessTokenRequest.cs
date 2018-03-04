using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.auth
{
    [DataContract]
    public class GetAccessTokenRequest
    {
        public GetAccessTokenRequest(string phoneNumber, string password)
        {
            PhoneNumber = phoneNumber;
            Password = password;
        }

        [DataMember(IsRequired = true)]
        public string PhoneNumber { get; }
        
        [DataMember(IsRequired = true)]
        public string Password { get; }
    }
}