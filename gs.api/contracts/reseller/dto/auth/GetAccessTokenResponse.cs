using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.auth
{
    [DataContract]
    public class GetAccessTokenResponse
    {
        public GetAccessTokenResponse(string phoneNumber, string token)
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