using JetBrains.Annotations;

namespace gs.api.storage.model.resellers.dicts.spec
{
    /// <summary>
    /// Specification of a good.
    /// </summary>
    public class Specification : BaseDbWithOwner
    {
        [UsedImplicitly]
        public Specification()
        {
        }
        
        public Specification(long ownerId): base(ownerId)
        {
        }

        public Specification(long ownerId, long id, string name) : base(ownerId)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; set; }
        
        public override void UpdateFieldsFrom(BaseDbEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}