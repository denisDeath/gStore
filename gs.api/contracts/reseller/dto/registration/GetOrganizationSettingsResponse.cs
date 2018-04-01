using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.registration
{
    [DataContract]
    public class GetOrganizationSettingsResponse : BaseRequest
    {
        public GetOrganizationSettingsResponse(OrganizationSettings settings)
        {
            Settings = settings;
        }

        [DataMember(IsRequired = true)]
        public OrganizationSettings Settings { get; set; }
    }
}