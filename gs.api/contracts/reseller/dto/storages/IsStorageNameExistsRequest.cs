using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.storages
{
    [DataContract]
    public class IsStorageNameExistsRequest
    {
        public IsStorageNameExistsRequest(string storageName)
        {
            StorageName = storageName;
        }

        [DataMember(IsRequired = true)]
        public string StorageName { get; }
    }
}