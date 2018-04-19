namespace gs.api.storage.model.resellers.dicts.spec
{
    /// <summary>
    /// Boolean value of specification.
    /// </summary>
    public class BoolSpecificationValue : SpecificationValue<BoolSpecification>
    {
        public bool Value { get; set; }
    }
}