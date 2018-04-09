using gs.api.auth;
using gs.api.contracts.reseller.dto.dicts.goodCategories;
using gs.api.contracts.reseller.services.interfaces.dicts;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gs.api.controllers.resellers.dicts
{
    [Route("api/resellers/goodCategories/list/[action]")]
    [Authorize(Roles = Roles.ResellerAdmin)]
    public class GoodCategoriesController : BaseEntityController<GoodCategory>
    {
        public GoodCategoriesController([NotNull] ICrudService<GoodCategory> crudService) : base(crudService)
        {
        }
    }
}