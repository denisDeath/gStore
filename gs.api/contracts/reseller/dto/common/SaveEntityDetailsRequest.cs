using System.Runtime.Serialization;
using gs.api.contracts.reseller.dto.dicts.goods;

namespace gs.api.contracts.reseller.dto.goods
{
    [DataContract]
    public class SaveEntityDetailsRequest<T> : BaseRequest
    {
        [DataMember(IsRequired = true)]
        public T Entity { get; set; }
    }
}