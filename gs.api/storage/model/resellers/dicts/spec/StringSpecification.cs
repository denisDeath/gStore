using JetBrains.Annotations;

namespace gs.api.storage.model.resellers.dicts.spec
{
    /// <summary>
    /// Specification of good by string value.
    /// </summary>
    public class StringSpecification : Specification
    {
        [UsedImplicitly]
        public StringSpecification()
        {
        }
        
        public StringSpecification(long ownerId) : base(ownerId)
        {
        }

        public StringSpecification(long ownerId, long id, string name) : base(ownerId, id, name)
        {
        }
    }
}