using GoodCategory = gs.api.contracts.reseller.dto.dicts.goodCategories.GoodCategory;
using GoodCategoryDb = gs.api.storage.model.resellers.dicts.GoodCategory;

namespace gs.api.converters
{
    public class GoodCategoryMapper : IEntityMapper<GoodCategory, GoodCategoryDb>
    {
        public GoodCategoryDb MapToDb(GoodCategory dto)
        {
            return new GoodCategoryDb(dto.Id, dto.Name,
                dto.Description, dto.ImageUrl);
        }

        public GoodCategory MapToDto(GoodCategoryDb dbEntity)
        {
            return new GoodCategory(dbEntity.Id, dbEntity.Name,
                dbEntity.Description, dbEntity.ImageUrl);
        }
    }
}