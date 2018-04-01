using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.dicts.stores
{
    [DataContract]
    public class SaveDetailsRequest : BaseRequest
    {
        public SaveDetailsRequest(Store store)
        {
            Store = store;
        }

        [DataMember(IsRequired = true)]
        public Store Store { get; set; }
    }
}