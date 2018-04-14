using System;
using gs.api.contracts.reseller.dto.common;
using gs.api.contracts.reseller.dto.goods;
using gs.api.contracts.reseller.services.interfaces.dicts;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;

namespace gs.api.controllers.resellers.dicts
{
    public abstract class BaseEntityController<T> : BaseController
    {
        private readonly ICrudService<T> _crudService;

        public BaseEntityController([NotNull] ICrudService<T> crudService)
        {
            _crudService = crudService ?? throw new ArgumentNullException(nameof(crudService));
        }

        [HttpPost]
        public GetEntitiesResponse<T> GetAll()
        {
            return _crudService.GetAll();
        }

        [HttpPost]
        public AddEntityResponse Add([NotNull] [FromBody] AddEntityRequest<T> request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            var result = _crudService.Add(request);
            return result;
        }

        [HttpPost]
        public void Remove([NotNull] [FromBody] RemoveEntitiesRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            _crudService.Remove(request);
        }
        
        [HttpPost]
        public void Save([NotNull] [FromBody] SaveEntityDetailsRequest<T> request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            _crudService.Save(request);
        }

        [HttpPost]
        public GetEntityDetailsResponse<T> GetDetails([NotNull] [FromBody] GetEntityDetailsRequest request)
        {
            var result = _crudService.GetDetails(request);
            return result;
        }
    }
}