using System.Collections.Generic;
using System.Runtime.Serialization;
using gs.api.contracts.reseller.dto.dicts.goods;

namespace gs.api.contracts.reseller.dto.goods
{
    [DataContract]
    public class GetEntitiesResponse<T>
    {
        public GetEntitiesResponse(IEnumerable<T> entities)
        {
            Entities = entities;
        }

        [DataMember]
        public IEnumerable<T> Entities { get; }
    }
}