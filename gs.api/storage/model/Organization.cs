using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gs.api.storage.model
{
    public abstract class Organization
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public long OrganizationId { get; set; }
        
        [Required, ForeignKey(nameof(User.UserId))]
        public User Owner { get; set; }
        
        [Required, MinLength(3), MaxLength(50)]
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
    }
}