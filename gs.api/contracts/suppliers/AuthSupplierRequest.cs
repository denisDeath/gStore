using System.Runtime.Serialization;

namespace gs.api.contracts.suppliers
{
    [DataContract]
    public class AuthRequest
    {
        public AuthRequest(string supplierId, string supplierPassword)
        {
            SupplierId = supplierId;
            SupplierPassword = supplierPassword;
        }

        [DataMember(IsRequired = true)]
        public string SupplierId { get; }
        
        [DataMember(IsRequired = true)]
        public string SupplierPassword { get; }
    }
}