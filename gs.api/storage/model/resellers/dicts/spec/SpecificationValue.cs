using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gs.api.storage.model.resellers.dicts.spec
{
    /// <summary>
    /// Value of specification.
    /// </summary>
    /// <typeparam name="TParentSpecification">Type of parent specification, which ownes this value.</typeparam>
    public class SpecificationValue<TParentSpecification> : BaseDbWithOwner
        where TParentSpecification: Specification
    {
        [Required, ForeignKey(nameof(Specification.Id))]
        public TParentSpecification ParentSpecification { get; set; }
        
        public override void UpdateFieldsFrom(BaseDbEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}