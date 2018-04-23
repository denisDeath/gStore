using Specification = gs.api.contracts.reseller.dto.dicts.specs.Specification;
using SpecificationDb = gs.api.storage.model.resellers.dicts.spec.Specification; 

namespace gs.api.converters.reseller
{
    public class SpecificationMapper: IEntityMapper<Specification, SpecificationDb>
    {
        public SpecificationDb MapToDb(Specification dto, long ownerId)
        {
            return new SpecificationDb(ownerId, dto.Id, dto.Name);
        }

        public Specification MapToDto(SpecificationDb dbEntity)
        {
            throw new System.NotImplementedException();
        }
    }
}