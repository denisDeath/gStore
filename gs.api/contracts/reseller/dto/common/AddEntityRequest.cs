using System.Runtime.Serialization;
using gs.api.contracts.reseller.dto.dicts.goodCategories;
using Newtonsoft.Json;

namespace gs.api.contracts.reseller.dto.common
{
    [DataContract]
    [KnownType(typeof(GoodCategory))]
    public class AddEntityRequest<T> : BaseRequest
    {
        [DataMember(IsRequired = true)]
        public T EntityToAdd { get; set; }
    }
}