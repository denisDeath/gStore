namespace gs.api.storage.model
{
    public abstract class BaseDbEntity
    {
        public long Id { get; }
        public abstract void UpdateFieldsFrom(BaseDbEntity entity);
    }
}