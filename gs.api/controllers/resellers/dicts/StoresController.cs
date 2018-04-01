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
    [Route("api/resellers/stores/[action]")]
    [Authorize(Roles = Roles.ResellerAdmin)]
    public class StoresController : Controller
    {
        private readonly IStoresService StoresService;

        public StoresController([NotNull] IStoresService Service)
        {
            StoresService = Service ?? throw new ArgumentNullException(nameof(Service));
        }

        [HttpPost]
        public GetResponse Get()
        {
            return StoresService.Get();
        }

        [HttpPost]
        public AddResponse Add([NotNull] [FromBody] AddRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            return StoresService.Add(request);
        }

        [HttpPost]
        public void Remove([NotNull] [FromBody] RemoveRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            StoresService.Remove(request);
        }
        
        [HttpPost]
        public void SaveDetails([NotNull] [FromBody] SaveDetailsRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            StoresService.SaveDetails(request);
        }

        [HttpPost]
        public GetDetailsResponse GetDetails([NotNull] [FromBody] GetDetailsRequest request)
        {
            return StoresService.GetDetails(request);
        }
    }
}