using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.registration
{
    [DataContract]
    public class IsOrganizationExistsRequest
    {
        public IsOrganizationExistsRequest(string trademark, string inn)
        {
            Trademark = trademark;
            Inn = inn;
        }

        [DataMember(IsRequired = true)]
        public string Trademark { get; }
        
        [DataMember(IsRequired = true)]
        public string Inn { get; }
    }
}