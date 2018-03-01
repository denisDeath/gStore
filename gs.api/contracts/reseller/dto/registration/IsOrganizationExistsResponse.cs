using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.registration
{
    [DataContract]
    public class IsOrganizationExistsResponse
    {
        public IsOrganizationExistsResponse(bool existsByTrademark, bool existsByInn)
        {
            ExistsByTrademark = existsByTrademark;
            ExistsByInn = existsByInn;
        }

        [DataMember(IsRequired = true)]
        public bool ExistsByTrademark { get; }
        
        [DataMember(IsRequired = true)]
        public bool ExistsByInn { get; }
    }
}