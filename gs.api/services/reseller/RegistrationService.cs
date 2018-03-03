using System;
using System.Linq;
using System.Text;
using gs.api.contracts.reseller;
using gs.api.contracts.reseller.dto.exceptions;
using gs.api.contracts.reseller.dto.registration;
using gs.api.contracts.reseller.services.interfaces;
using gs.api.converters.reseller;
using gs.api.storage;
using JetBrains.Annotations;

using OrganizationDb = gs.api.storage.model.Organization;
using UserDb = gs.api.storage.model.User;

namespace gs.api.services.reseller
{
    public class RegistrationService : IRegistrationService
    {
        private readonly Context Context;
        private const uint TokenExpirationInMinutes = 10;

        public RegistrationService(Context context)
        {
            Context = context;
        }

        public RegisterOrganizationResponse RegisterOrganization([NotNull] RegisterOrganizationRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            // add user
            if (IsUserExistsByPhone(request.UserPhoneNumber))
                throw new UserAlreadyExistsException();
            UserDb user = request.ConvertToUser();
            Context.Add(user);
            
            // add organization
            if (IsOrgExistsByByTrademark(request.OrganizationTrademark))
                throw new OrganizationAlreadyExistsException();
            var org = request.ConvertToOrganization();
            org.Owner = user;
            Context.Add(org);
            Context.SaveChanges();
            
            // generate token
            byte[] bytes = Encoding.UTF8.GetBytes(Guid.NewGuid().ToString());
            user.Token = Convert.ToBase64String(bytes);
            user.TokenExpireDate = DateTime.UtcNow.AddMinutes(TokenExpirationInMinutes);
            Context.SaveChanges();
            return new RegisterOrganizationResponse(user.Token);
        }

        public IsAccountExistsResponse IsAccountExists([NotNull] IsAccountExistsRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            bool byTrademark = IsOrgExistsByByTrademark(request.Trademark);
            bool byPhone = IsUserExistsByPhone(request.UserPhoneNumber);
            return new IsAccountExistsResponse(byTrademark, byPhone);
        }

        private bool IsOrgExistsByByTrademark(string tradeMark)
        {
            bool byTrademarkIe = Context.IeOrganizations.Any(o => o.TradeMark == tradeMark);
            bool byTrademarkLtd = Context.LtdOrganizations.Any(o => o.TradeMark == tradeMark);
            return byTrademarkIe || byTrademarkLtd;
        }
        
        private bool IsUserExistsByPhone(string userPhone)
        {
            return Context.Users.Any(u => u.PhoneNumber == userPhone);
        }
    }
}