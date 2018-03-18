using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.registration
{
    [DataContract]
    public class ChangePhoneNumberRequest : BaseRequest
    {
        public ChangePhoneNumberRequest(string newPhoneNumber)
        {
            NewPhoneNumber = newPhoneNumber;
        }

        [DataMember(IsRequired = true)]
        public string NewPhoneNumber { get; set; }
    }
}