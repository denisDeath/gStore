using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.auth
{
    [DataContract]
    public class GetAccessTokenRequest
    {
        public GetAccessTokenRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }

        [DataMember(IsRequired = true)]
        public string Email { get; }
        
        [DataMember(IsRequired = true)]
        public string Password { get; }
    }
}