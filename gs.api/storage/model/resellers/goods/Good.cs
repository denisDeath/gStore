using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JetBrains.Annotations;

namespace gs.api.storage.model.resellers.goods
{
    public class Good
    {
        [UsedImplicitly]
        public Good() { }
        
        public Good(long ownerId, long id, string name, string description, string imageUris, string barcode,
            string vendorCode, string unit)
        {
            Owner = new Organization
            {
                OrganizationId = ownerId
            };
            Id = id;
            Name = name;
            Description = description;
            ImageUris = imageUris;
            Barcode = barcode;
            VendorCode = vendorCode;
            Unit = unit;
        }

        public Good(long ownerId)
        {
            Owner = new Organization
            {
                OrganizationId = ownerId
            };
        }
        
        [Required, ForeignKey(nameof(Organization.OrganizationId))]
        public Organization Owner { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public long Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        /// <summary>
        /// Comma separated list of uris.
        /// </summary>
        public string ImageUris { get; set; }
        
        public string Barcode { get; set; }
        
        /// <summary>
        /// Артикул.
        /// </summary>
        public string VendorCode { get; set; }
        
        public string Unit { get; set; }

        public void UpdateFieldsFrom(Good source)
        {
            Name = source.Name;
            Description = source.Description;
            ImageUris = source.ImageUris;
            Barcode = source.Barcode;
            VendorCode = source.VendorCode;
            Unit = source.Unit;
        }
    }
}