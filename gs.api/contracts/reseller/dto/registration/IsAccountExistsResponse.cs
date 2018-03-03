using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.registration
{
    [DataContract]
    public class IsAccountExistsResponse
    {
        public IsAccountExistsResponse(bool existsByTrademark, bool existsByUserPhoneNumber)
        {
            ExistsByTrademark = existsByTrademark;
            ExistsByUserPhoneNumber = existsByUserPhoneNumber;
        }

        [DataMember(IsRequired = true)]
        public bool ExistsByTrademark { get; }
        
        [DataMember(IsRequired = true)]
        public bool ExistsByUserPhoneNumber { get; }
    }
}