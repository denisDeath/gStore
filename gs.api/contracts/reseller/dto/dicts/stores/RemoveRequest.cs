using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.dicts.stores
{
    [DataContract]
    public class RemoveRequest : BaseRequest
    {
        public RemoveRequest(long storeId)
        {
            StoreId = storeId;
        }

        [DataMember(IsRequired = true)]
        public long StoreId { get; }
    }
}