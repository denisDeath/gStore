using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.registration
{
    [DataContract]
    public class IsAccountExistsResponse
    {
        public IsAccountExistsResponse(bool existsByUserPhoneNumber)
        {
            ExistsByUserPhoneNumber = existsByUserPhoneNumber;
        }

        [DataMember(IsRequired = true)]
        public bool ExistsByUserPhoneNumber { get; }
    }
}