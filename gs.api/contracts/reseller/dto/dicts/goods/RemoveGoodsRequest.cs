using System.Collections.Generic;
using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.goods
{
    [DataContract]
    public class RemoveGoodsRequest : BaseRequest
    {
        public RemoveGoodsRequest(IEnumerable<long> idsToRemove)
        {
            IdsToRemove = idsToRemove;
        }

        [DataMember(IsRequired = true)]
        public IEnumerable<long> IdsToRemove { get; }
    }
}