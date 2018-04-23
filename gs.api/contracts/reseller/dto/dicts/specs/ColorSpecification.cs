namespace gs.api.contracts.reseller.dto.dicts.specs
{
    /// <summary>
    /// Specification of good by one of predefined colour value.
    /// </summary>
    public class ColorSpecification : Specification
    {
        public ColorSpecification(long id, string name, SpecificationType specificationType) : base(id, name, specificationType)
        {
        }
    }
}