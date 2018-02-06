using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.stores
{
    [DataContract]
    public class IsStoreNameExistsRequest
    {
        public IsStoreNameExistsRequest(string name)
        {
            Name = name;
        }

        [DataMember(IsRequired = true)]
        public string Name { get; }
    }
}