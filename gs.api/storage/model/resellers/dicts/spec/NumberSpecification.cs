using JetBrains.Annotations;

namespace gs.api.storage.model.resellers.dicts.spec
{
    /// <summary>
    /// Specification of good by number value.
    /// </summary>
    public class NumberSpecification : Specification
    {
        public string UnitOfMeasure { get; set; }

        [UsedImplicitly]
        public NumberSpecification()
        {
            
        }
        
        public NumberSpecification(long ownerId) : base(ownerId)
        {
        }

        public NumberSpecification(long ownerId, long id, string name, string unitOfMeasure) : base(ownerId, id, name)
        {
            UnitOfMeasure = unitOfMeasure;
        }
    }
}