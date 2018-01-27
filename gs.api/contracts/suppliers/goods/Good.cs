using System.Runtime.Serialization;

namespace gs.api.contracts.suppliers.goods
{
    [DataContract]
    public class Good : IGoodId
    {
        public Good(long id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        [DataMember(IsRequired = true)]
        public long Id { get; }
        
        [DataMember(IsRequired = true)]
        public string Name { get; }
        
        [DataMember]
        public string Description { get; }
    }
}