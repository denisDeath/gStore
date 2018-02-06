using System.Collections.Generic;
using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.stores
{
    [DataContract]
    public class GetStoresResponse
    {
        public GetStoresResponse(IEnumerable<StoreInfo> stores)
        {
            Stores = stores;
        }

        public IEnumerable<StoreInfo> Stores { get; }
    }
}