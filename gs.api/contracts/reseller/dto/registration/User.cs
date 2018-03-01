using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.registration
{
    /// <summary>
    /// Пользователь-реселлер.
    /// </summary>
    [DataContract] 
    public class User
    {
        public User(string name, string email, string password, UserRole role)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
        }

        [DataMember(IsRequired = true)]
        public string Name { get; }
        
        [DataMember(IsRequired = true)]
        public string Email { get; }
        
        [DataMember(IsRequired = true)]
        public string Password { get; }
        
        [DataMember(IsRequired = true)]
        public UserRole Role { get; }
    }
}