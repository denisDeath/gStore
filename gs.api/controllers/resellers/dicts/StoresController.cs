using System;
using gs.api.auth;
using gs.api.contracts.reseller.dto.dicts.stores;
using gs.api.contracts.reseller.dto.goods;
using gs.api.contracts.reseller.services.interfaces.dicts;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gs.api.controllers.resellers.dicts
{
    [Route("api/resellers/stores/list/[action]")]
    [Authorize(Roles = Roles.ResellerAdmin)]
    public class StoresController : BaseEntityController<Store>
    {
        public StoresController([NotNull] ICrudService<Store> crudService) : base(crudService)
        {
        }
    }
}