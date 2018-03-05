﻿using gs.api.contracts.reseller.dto.exceptions;
using gs.api.contracts.reseller.dto.registration;
using Microsoft.AspNetCore.Mvc;

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

        /// <summary>
        /// Сохранить настройки организации или её владельца.
        /// Настройка сохраняется только если соответствующее поле != null.
        /// </summary>
        [Throws(typeof(UnauthorizedException))]
        void SaveOrganizationSettings(SaveOrganizationSettingsRequest request);

        /// <summary>
        /// Изменить пароль.
        /// </summary>
        [Throws(typeof(UnauthorizedException))]
        void ChangePassword(ChangePasswordRequest request);

        /// <summary>
        /// Изменить номер телефона.
        /// </summary>
        [Throws(typeof(UnauthorizedException))]
        [Throws(typeof(UserPhoneAlreadyInUseException))]
        void ChangePhoneNumber(ChangePhoneNumberRequest request);
    }
}