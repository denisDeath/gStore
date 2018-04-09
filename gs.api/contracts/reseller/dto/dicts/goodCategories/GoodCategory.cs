using System.Runtime.Serialization;
using gs.api.contracts.reseller.dto.common;

namespace gs.api.contracts.reseller.dto.dicts.goodCategories
{
    [DataContract]
    public class GoodCategory : BaseDtoEntity
    {
        public GoodCategory(long id, string name, string description, string imageUrl)
        {
            Id = id;
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
        }

        [DataMember(IsRequired = true)]
        public override long Id { get; set; }
        
        [DataMember(IsRequired = true)]
        public string Name { get; set; }
        
        [DataMember(IsRequired = false)]
        public string Description { get; set; }
        
        [DataMember(IsRequired = false)]
        public string ImageUrl { get; set; }
    }
}