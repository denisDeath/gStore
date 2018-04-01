using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gs.api.storage.model
{
    public class Organization
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public long OrganizationId { get; set; }
        
        [Required, ForeignKey(nameof(User.UserId))]
        public User Owner { get; set; }
        
        [MinLength(3), MaxLength(50)]
        public string TradeMark { get; set; }
        
        [MaxLength(50)]
        public string FullName { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }
        
        [MaxLength(50)]
        public string Phone { get; set; }
        
        /// <summary>
        /// инн
        /// </summary>
        [MaxLength(50)]
        public string Inn { get; set; }
        
        /// <summary>
        /// Работает с НДС.
        /// </summary>
        public bool UseVat { get; set; }

        public void UpdateFields(Organization source)
        {
            TradeMark = source.TradeMark;
            FullName = source.FullName;
            Address = source.Address;
            Inn = source.Inn;
            UseVat = source.UseVat;
            Phone = source.Phone;
        }
    }
}