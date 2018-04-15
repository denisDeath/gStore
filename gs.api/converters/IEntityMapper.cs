namespace gs.api.converters
{
    public interface IEntityMapper<TDto, TDb>
    {
        TDb MapToDb(TDto dto, long ownerId);
        TDto MapToDto(TDb dbEntity);
    }
}