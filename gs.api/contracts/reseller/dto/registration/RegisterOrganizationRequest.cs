using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.registration
{
    [DataContract]
    public class RegisterOrganizationRequest
    {
        public RegisterOrganizationRequest(string userPhoneNumber, string password, string firstName, string lastame,
            string patronymic)
        {
            UserPhoneNumber = userPhoneNumber;
            Password = password;
            FirstName = firstName;
            Lastame = lastame;
            Patronymic = patronymic;
        }

        [DataMember(IsRequired = true)]
        public string UserPhoneNumber { get; }
        
        [DataMember(IsRequired = true)]
        public string Password { get; }
        
        [DataMember(IsRequired = true)]
        public string FirstName { get; }
        
        [DataMember(IsRequired = false)]
        public string Lastame { get; }
        
        [DataMember(IsRequired = false)]
        public string Patronymic { get; }
    }
}