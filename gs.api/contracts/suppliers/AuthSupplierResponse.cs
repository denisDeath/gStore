using System.Runtime.Serialization;

namespace gs.api.contracts.suppliers
{
    [DataContract]
    public class AuthResponse
    {
        public AuthResponse(string token, string tokenTimeToLiveSec)
        {
            Token = token;
            TokenTimeToLiveSec = tokenTimeToLiveSec;
        }

        [DataMember]
        public string Token { get; }
        
        [DataMember]
        public string TokenTimeToLiveSec { get; }
    }
}