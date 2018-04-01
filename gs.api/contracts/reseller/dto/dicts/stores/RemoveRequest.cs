using System.Collections.Generic;
using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.dicts.stores
{
    [DataContract]
    public class RemoveRequest : BaseRequest
    {
        public RemoveRequest(IEnumerable<long> idsToRemove)
        {
            IdsToRemove = idsToRemove;
        }

        [DataMember(IsRequired = true)]
        public IEnumerable<long> IdsToRemove { get; }
    }
}