using System.Runtime.Serialization;

namespace gs.api.contracts.reseller
{
    /// <summary>
    /// Организация-реселлер.
    /// </summary>
    [DataContract]
    public class Organization
    {
        [DataMember(IsRequired = true)]
        public string Name { get; }
    }
}