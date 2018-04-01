using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.registration
{
    [DataContract]
    public class OrganizationSettings
    {
        public OrganizationSettings(string ownerFirstName, string ownerLastName, string ownerPatronymic,
            string tradeMark, string fullName, string address, string phone, string inn, bool useVat)
        {
            OwnerFirstName = ownerFirstName;
            OwnerLastName = ownerLastName;
            OwnerPatronymic = ownerPatronymic;
            TradeMark = tradeMark;
            FullName = fullName;
            Address = address;
            Phone = phone;
            Inn = inn;
            UseVat = useVat;
        }

        [DataMember(IsRequired = false)]
        public string OwnerFirstName { get; set; }
        
        [DataMember(IsRequired = false)]
        public string OwnerLastName { get; set; }
        
        [DataMember(IsRequired = false)]
        public string OwnerPatronymic { get; set; }
        
        [DataMember(IsRequired = false)]
        public string TradeMark { get; set; }
        
        [DataMember(IsRequired = false)]
        public string FullName { get; set; }
        
        [DataMember(IsRequired = false)]
        public string Address { get; set; }
        
        [DataMember(IsRequired = false)]
        public string Phone { get; set; }
        
        [DataMember(IsRequired = false)]
        public string Inn { get; set; }
        
        [DataMember(IsRequired = false)]
        public bool UseVat { get; set; }
    }
}