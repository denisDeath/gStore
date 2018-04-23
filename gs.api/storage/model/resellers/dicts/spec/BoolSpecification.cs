using JetBrains.Annotations;

namespace gs.api.storage.model.resellers.dicts.spec
{
    /// <summary>
    /// Specification of good by boolean value.
    /// </summary>
    public class BoolSpecification : Specification
    {
        [UsedImplicitly]
        public BoolSpecification()
        {
        }
        
        public BoolSpecification(long ownerId) : base(ownerId)
        {
        }

        public BoolSpecification(long ownerId, long id, string name) : base(ownerId, id, name)
        {
        }
    }
}