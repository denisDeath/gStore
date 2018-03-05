using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.registration
{
    [DataContract]
    public class IsAccountExistsRequest
    {
        public IsAccountExistsRequest(string userPhoneNumber)
        {
            UserPhoneNumber = userPhoneNumber;
        }
        
        [DataMember(IsRequired = true)]
        public string UserPhoneNumber { get; }
    }
}