using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.dicts.stores
{
    [DataContract]
    public class AddResponse
    {
        public AddResponse(long addedId)
        {
            AddedId = addedId;
        }

        [DataMember(IsRequired = true)]
        public long AddedId { get; set; }
    }
}