using System.Runtime.Serialization;

namespace gs.api.contracts.reseller
{
    [DataContract]
    public class IsOrganizationNameExistsRequest
    {
        public IsOrganizationNameExistsRequest(string organizationName)
        {
            OrganizationName = organizationName;
        }

        [DataMember(IsRequired = true)]
        public string OrganizationName { get; }
    }
}