namespace gs.api.storage.model.resellers.dicts.spec
{
    /// <summary>
    /// Color value of specification.
    /// </summary>
    public class ColorSpecificationValue : SpecificationValue<ColorSpecification>
    {
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
        public string Name { get; set; }
    }
}