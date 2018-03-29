namespace gs.api.storage.model.resellers.goods
{
    public class Good
    {
        public Good(long id, string name, string description, string imageUris, string barcode, string vendorCode,
            string unit)
        {
            Id = id;
            Name = name;
            Description = description;
            ImageUris = imageUris;
            Barcode = barcode;
            VendorCode = vendorCode;
            Unit = unit;
        }

        public Good()
        {
            
        }
        
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
    }
}