using System.Collections.Generic;
using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.goods
{
    [DataContract]
    public class RemoveEntitiesRequest : BaseRequest
    {
        [DataMember(IsRequired = true)]
        public List<long> IdsToRemove { get; set; }
    }
}