using gs.api.contracts.reseller.dto.exceptions;
using gs.api.contracts.reseller.dto.registration;

namespace gs.api.contracts.reseller.services.interfaces
{
    /// <summary>
    /// Методы для регистрации организации.
    /// </summary>
    public interface IRegistrationService
    {
        /// <summary>
        /// Метод регистрации организации-реселлера.
        /// </summary>
        [Throws(typeof(OrganizationAlreadyExistsException))]
        [Throws(typeof(UserAlreadyExistsException))] 
        RegisterOrganizationResponse RegisterOrganization(RegisterOrganizationRequest request);
        
        /// <summary>
        /// Проверка, есть ли уже организация с указанным именем.
        /// </summary>
        IsAccountExistsResponse IsAccountExists(IsAccountExistsRequest request);
    }
}