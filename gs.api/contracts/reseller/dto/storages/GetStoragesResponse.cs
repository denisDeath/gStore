using System.Collections.Generic;
using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.storages
{
    [DataContract]
    public class GetStoragesResponse
    {
        public GetStoragesResponse(IEnumerable<StorageInfo> storages)
        {
            Storages = storages;
        }

        [DataMember(IsRequired = true)] 
        public IEnumerable<StorageInfo> Storages { get; }
    }
}