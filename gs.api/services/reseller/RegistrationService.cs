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
            UserDb user = request.ConvertToUser();
            var existingUser = Context.Users.FirstOrDefault(u => u.PhoneNumber == user.PhoneNumber);
            if (existingUser != null)
                throw new UserAlreadyExistsException();
            Context.Add(user);
            
            // add organization
            var org = request.ConvertToOrganization();
            if (IsOrgExistsByByTrademark(org.TradeMark) || IsOrganizationExistsByInn(org.Inn))
                throw new OrganizationAlreadyExistsException();
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

        public IsOrganizationExistsResponse IsOrganizationExists([NotNull] IsOrganizationExistsRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            bool byTrademark = IsOrgExistsByByTrademark(request.Trademark);
            bool byInn = IsOrganizationExistsByInn(request.Inn);
            return new IsOrganizationExistsResponse(byTrademark, byInn);
        }

        public bool IsUserEmailExists([NotNull] IsUserEmailExistsRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            return Context.Users.Any(u => u.PhoneNumber == request.Email);
        }
        
        private bool IsOrgExistsByByTrademark(string tradeMark)
        {
            bool byTrademarkIe = Context.IeOrganizations.Any(o => o.TradeMark == tradeMark);
            bool byTrademarkLtd = Context.LtdOrganizations.Any(o => o.TradeMark == tradeMark);
            return byTrademarkIe || byTrademarkLtd;
        }
        
        private bool IsOrganizationExistsByInn(string inn)
        {
            bool byInnIe = Context.IeOrganizations.Any(o => o.Inn == inn);
            bool byInn = Context.LtdOrganizations.Any(o => o.Inn == inn);
            return byInnIe || byInn;
        }
    }
}