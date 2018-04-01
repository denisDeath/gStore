using System.Collections.Generic;
using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.dicts.goods
{
    [DataContract]
    public class Good
    {
        public Good(long id, string name, string description, IEnumerable<string> imageUris, string barcode,
            string vendorCode, string unit)
        {
            Id = id;
            Name = name;
            Description = description;
            ImageUris = imageUris;
            Barcode = barcode;
            VendorCode = vendorCode;
            Unit = unit;
        }

        [DataMember(IsRequired = true)]
        public long Id { get; set; }
        
        [DataMember(IsRequired = true)]
        public string Name { get; set; }
        
        [DataMember(IsRequired = true)]
        public string Description { get; set; }
        
        [DataMember(IsRequired = true)]
        public IEnumerable<string> ImageUris { get; set; }
        
        [DataMember(IsRequired = true)]
        public string Barcode { get; set; }
        
        [DataMember(IsRequired = true)]
        public string VendorCode { get; set; }
        
        [DataMember(IsRequired = true)]
        public string Unit { get; set; }
    }
}