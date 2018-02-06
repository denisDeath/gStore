using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.stores
{
    [DataContract]
    public class AddStoreRequest
    {
        public AddStoreRequest(StoreInfo store)
        {
            Store = store;
        }

        [DataMember(IsRequired = true)]
        public StoreInfo Store { get; }
    }
}