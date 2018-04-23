using gs.api.auth;
using gs.api.contracts.reseller.dto.dicts.specs;
using gs.api.contracts.reseller.services.interfaces.dicts;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gs.api.controllers.resellers.dicts
{
    [Route("api/resellers/specifications/list/[action]")]
    [Authorize(Roles = Roles.ResellerAdmin)]
    public class SpecificationsController : BaseEntityController<Specification>
    {
        public SpecificationsController([NotNull] ICrudService<Specification> crudService) : base(crudService)
        {
        }
    }
}