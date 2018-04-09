namespace gs.api.converters
{
    public interface IEntityMapper<TDto, TDb>
    {
        TDb MapToDb(TDto dto);
        TDto MapToDto(TDb dbEntity);
    }
}