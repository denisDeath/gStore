using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.common
{
    [DataContract]
    public class AddEntityResponse
    {
        public AddEntityResponse(long addedEntityId)
        {
            AddedEntityId = addedEntityId;
        }

        [DataMember(IsRequired = true)]
        public long AddedEntityId { get; set; }
    }
}