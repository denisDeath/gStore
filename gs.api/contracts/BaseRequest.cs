using System.Runtime.Serialization;

namespace gs.api.contracts
{
    [DataContract]
    public class BaseRequest
    {
        public BaseRequest(string token)
        {
            Token = token;
        }

        public string Token { get; }
    }
}