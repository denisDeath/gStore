using System.Runtime.Serialization;
using gs.api.contracts.reseller.dto.common;

namespace gs.api.contracts.reseller.dto.dicts.specs
{
    /// <summary>
    /// Specification of a good.
    /// </summary>
    public class Specification : BaseDtoEntity
    {
        [DataMember(IsRequired = true)]
        public override long Id { get; set; }
        
        [DataMember(IsRequired = true)]
        public string Name { get; set; }
        
        [DataMember(IsRequired = true)]
        public SpecificationType SpecificationType { get; set; }

        public Specification(long id, string name, SpecificationType specificationType)
        {
            Id = id;
            Name = name;
            SpecificationType = specificationType;
        }
    }
}