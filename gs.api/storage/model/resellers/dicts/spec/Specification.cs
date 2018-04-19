namespace gs.api.storage.model.resellers.dicts.spec
{
    /// <summary>
    /// Specification of a good.
    /// </summary>
    public class Specification : BaseDbWithOwner
    {
        public string Name { get; set; }
        
        public override void UpdateFieldsFrom(BaseDbEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}