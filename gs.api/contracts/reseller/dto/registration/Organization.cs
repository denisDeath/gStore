using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.registration
{
    /// <summary>
    /// Организация-реселлер.
    /// </summary>
    [DataContract]
    public class Organization
    {
        public Organization(string name)
        {
            Name = name;
        }

        [DataMember(IsRequired = true)]
        public string Name { get; }
    }
}