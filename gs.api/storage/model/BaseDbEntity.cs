namespace gs.api.storage.model
{
    public abstract class BaseDbEntity
    {
        public abstract long Id { get; set; }
        public abstract void UpdateFieldsFrom(BaseDbEntity entity);
    }
}