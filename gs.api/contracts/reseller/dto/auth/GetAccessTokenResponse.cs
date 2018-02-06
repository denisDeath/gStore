using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.auth
{
    [DataContract]
    public class GetAccessTokenResponse
    {
        public GetAccessTokenResponse(string token)
        {
            Token = token;
        }

        [DataMember(IsRequired = true)]
        public string Token { get; }
    }
}