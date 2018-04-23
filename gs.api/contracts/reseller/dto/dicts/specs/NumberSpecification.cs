namespace gs.api.contracts.reseller.dto.dicts.specs
{
    /// <summary>
    /// Specification of good by number value.
    /// </summary>
    public class NumberSpecification : Specification
    {
        public string UnitOfMeasure { get; set; }

        public NumberSpecification(long id, string name, SpecificationType specificationType) : base(id, name, specificationType)
        {
        }
    }
}