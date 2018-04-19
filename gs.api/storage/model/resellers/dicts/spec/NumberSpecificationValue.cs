namespace gs.api.storage.model.resellers.dicts.spec
{
    /// <summary>
    /// Number (with decimal precision) value of specification. 
    /// </summary>
    public class NumberSpecificationValue : SpecificationValue<NumberSpecification>
    {
        public decimal Value { get; set; }
    }
}