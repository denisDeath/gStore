using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gs.api.storage.model
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public long UserId { get; set; }
        
        [Required, MinLength(3), MaxLength(50)]
        public string Email { get; set; }
        
        [Required, MinLength(5), MaxLength(50)]
        public string Password { get; set; }
        
        /// <summary>
        /// Токен для доступа к пользователю.
        /// </summary>
        public string Token { get; set; }
        
        /// <summary>
        /// Дата/время истечения времени жизни токена.
        /// </summary>
        public DateTime? TokenExpireDate { get; set; }
    }
}