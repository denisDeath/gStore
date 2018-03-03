using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.registration
{
    [DataContract]
    public class IsAccountExistsRequest
    {
        public IsAccountExistsRequest(string trademark, string userPhoneNumber)
        {
            Trademark = trademark;
            UserPhoneNumber = userPhoneNumber;
        }

        [DataMember(IsRequired = true)]
        public string Trademark { get; }
        
        [DataMember(IsRequired = true)]
        public string UserPhoneNumber { get; }
    }
}