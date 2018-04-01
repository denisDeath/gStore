using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gs.api.storage.model
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public long UserId { get; set; }
        
        [Required, MinLength(3), MaxLength(50)]
        public string FirstName { get; set; }
        
        [MaxLength(50)]
        public string LastName { get; set; }
        
        [MaxLength(50)]
        public string Patronymic { get; set; }
        
        [Required, MinLength(3), MaxLength(50)]
        public string PhoneNumber { get; set; }
        
        [Required, MinLength(5), MaxLength(50)]
        public string Password { get; set; }

        public void UpdateFieldsWithoutPasswordAndPhone(User source)
        {
            FirstName = source.FirstName;
            LastName = source.LastName;
            Patronymic = source.Patronymic;
        }
    }
}