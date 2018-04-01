using System.Collections.Generic;
using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.dicts.stores
{
    [DataContract]
    public class GetResponse
    {
        public GetResponse(IEnumerable<Store> stores)
        {
            Stores = stores;
        }

        [DataMember(IsRequired = true)]
        public IEnumerable<Store> Stores { get; }
    }
}