using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.registration
{
    [DataContract]
    public class ChangePasswordRequest : BaseRequest
    {
        public ChangePasswordRequest(string newPassword)
        {
            NewPassword = newPassword;
        }

        [DataMember(IsRequired = true)]
        public string NewPassword { get; set; }
    }
}