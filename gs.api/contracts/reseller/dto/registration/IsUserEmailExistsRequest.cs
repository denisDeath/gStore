using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.registration
{
    [DataContract]
    public class IsUserEmailExistsRequest
    {
        public IsUserEmailExistsRequest(string email)
        {
            Email = email;
        }

        [DataMember(IsRequired = true)]
        public string Email { get; }
    }
}