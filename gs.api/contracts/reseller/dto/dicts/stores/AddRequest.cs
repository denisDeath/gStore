using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.dicts.stores
{
    [DataContract]
    public class AddRequest
    {
        public AddRequest(Store store)
        {
            Store = store;
        }

        [DataMember(IsRequired = true)]
        public Store Store { get; }
    }
}