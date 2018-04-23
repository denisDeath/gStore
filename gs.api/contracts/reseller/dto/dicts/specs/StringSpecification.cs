namespace gs.api.contracts.reseller.dto.dicts.specs
{
    /// <summary>
    /// Specification of good by string value.
    /// </summary>
    public class StringSpecification : Specification
    {
        public StringSpecification(long id, string name, SpecificationType specificationType) : base(id, name, specificationType)
        {
        }
    }
}