namespace gs.api.contracts.reseller.dto.dicts.specs
{
    /// <summary>
    /// Specification of good by boolean value.
    /// </summary>
    public class BoolSpecification : Specification
    {
        public BoolSpecification(long id, string name, SpecificationType specificationType) : base(id, name, specificationType)
        {
        }
    }
}