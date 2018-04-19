using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JetBrains.Annotations;

namespace gs.api.storage.model.resellers.dicts
{
    public class Good : BaseDbWithOwner
    {
        [UsedImplicitly]
        public Good() { }
        
        public Good(long ownerId, long id, string name, string description, string imageUris, string barcode,
            string vendorCode, string unit): base(ownerId)
        {
            Id = id;
            Name = name;
            Description = description;
            ImageUris = imageUris;
            Barcode = barcode;
            VendorCode = vendorCode;
            Unit = unit;
        }

        public Good(long ownerId): base(ownerId)
        {
        }

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

        public override void UpdateFieldsFrom(BaseDbEntity entity)
        {
            var source = (Good) entity;
            if (source == null)
                throw new InvalidOperationException($"Parameter entity must be of {nameof(Good)} type.");
            
            Name = source.Name;
            Description = source.Description;
            ImageUris = source.ImageUris;
            Barcode = source.Barcode;
            VendorCode = source.VendorCode;
            Unit = source.Unit;
        }
    }
}