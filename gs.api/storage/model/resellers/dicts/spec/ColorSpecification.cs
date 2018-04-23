using JetBrains.Annotations;

namespace gs.api.storage.model.resellers.dicts.spec
{
    /// <summary>
    /// Specification of good by one of predefined colour value.
    /// </summary>
    public class ColorSpecification : Specification
    {
        [UsedImplicitly]
        public ColorSpecification()
        {
        }
        
        public ColorSpecification(long ownerId) : base(ownerId)
        {
        }

        public ColorSpecification(long ownerId, long id, string name) : base(ownerId, id, name)
        {
        }
    }
}