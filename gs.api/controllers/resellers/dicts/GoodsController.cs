using gs.api.auth;
using gs.api.contracts.reseller.dto.dicts.goods;
using gs.api.contracts.reseller.services.interfaces.dicts;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gs.api.controllers.resellers.dicts
{
    [Route("api/resellers/goods/list/[action]")]
    [Authorize(Roles = Roles.ResellerAdmin)]
    public class GoodsController : BaseEntityController<Good>
    {
        public GoodsController([NotNull] ICrudService<Good> crudService) : base(crudService)
        {
        }
    }
}