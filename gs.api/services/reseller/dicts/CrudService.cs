using System;
using System.Linq;
using gs.api.contracts.reseller.dto.common;
using gs.api.contracts.reseller.dto.goods;
using gs.api.contracts.reseller.services.interfaces.dicts;
using gs.api.converters;
using gs.api.converters.reseller;
using gs.api.infrastructure;
using gs.api.storage;
using JetBrains.Annotations;
using gs.api.storage.model;

namespace gs.api.services.reseller.dicts
{
    public class CrudService<T, TDb> : ICrudService<T> where T: BaseDtoEntity        
                                                       where TDb: BaseDbWithOwner
    {
        [NotNull] private readonly Context _context;
        [NotNull] private readonly CallContext _callContext;
        [NotNull] private readonly IEntityMapper<T, TDb> _entityMapper;

        public CrudService([NotNull] Context context, 
            [NotNull] CallContext callContext, 
            [NotNull] IEntityMapper<T, TDb> entityMapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _callContext = callContext ?? throw new ArgumentNullException(nameof(callContext));
            _entityMapper = entityMapper ?? throw new ArgumentNullException(nameof(entityMapper));
        }
        
        public GetEntitiesResponse<T> GetAll()
        {
            var entities = _context
                .Set<TDb>()
                .Where(g => g.Owner.OrganizationId == _callContext.CurrentOrganizationId)
                .ToList();
            return new GetEntitiesResponse<T>(entities.Select(_entityMapper.MapToDto));
        }

        public AddEntityResponse Add(AddEntityRequest<T> request)
        {
            var newEntity = _entityMapper.MapToDb(request.EntityToAdd, _callContext.CurrentOrganizationId);
            _context.Set<TDb>().Add(newEntity);
            _context.SaveChanges();
            return new AddEntityResponse(newEntity.Id);
        }

        public void Remove(RemoveEntitiesRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            
            // чтобы удалить сущность, мы вытягиваем её из БД.
            // TODO: надо просто удалять по идентификатору/ам без лишних накладных расходов.
            foreach (long idToRemove in request.IdsToRemove)
            {
                var entityToRemove = _context.Set<TDb>().FirstOrDefault(g => g.Id == idToRemove);
                if (entityToRemove != null)
                    _context.Remove(entityToRemove);
            }
            _context.SaveChanges();
        }

        public void Save(SaveEntityDetailsRequest<T> request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var entityFromDb = _context.Set<TDb>().FirstOrDefault(g => g.Id == request.Entity.Id);
            if (entityFromDb == null)
                throw new InvalidOperationException($"Entity {typeof(T)} with id {request.Entity.Id} not found.");

            var changedDbEntity = _entityMapper.MapToDb(request.Entity, _callContext.CurrentOrganizationId);
            entityFromDb.UpdateFieldsFrom(changedDbEntity);
            _context.SaveChanges();
        }

        public GetEntityDetailsResponse<T> GetDetails(GetEntityDetailsRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            var entity = _context.Set<TDb>().FirstOrDefault(g => g.Id == request.EntityId);
            if (entity == null)
                throw new Exception($"Entity {typeof(T)} with id {request.EntityId} not found.");
            
            return new GetEntityDetailsResponse<T>(_entityMapper.MapToDto(entity));
        }
    }
}