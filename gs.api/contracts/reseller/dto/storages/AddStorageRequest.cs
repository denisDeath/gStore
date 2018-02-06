using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.storages
{
    [DataContract]
    public class AddStorageRequest
    {
        public AddStorageRequest(StorageInfo storage)
        {
            Storage = storage;
        }

        [DataMember(IsRequired = true)]
        public StorageInfo Storage { get; }
    }
}