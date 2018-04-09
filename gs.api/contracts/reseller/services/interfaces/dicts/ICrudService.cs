using gs.api.contracts.reseller.dto.common;
using gs.api.contracts.reseller.dto.goods;

namespace gs.api.contracts.reseller.services.interfaces.dicts
{
    public interface ICrudService<T>
    {
        GetEntitiesResponse<T> GetAll();
        AddEntityResponse Add(AddEntityRequest<T> request);
        void Remove(RemoveEntitiesRequest request);
        void Save(SaveEntityDetailsRequest<T> request);
        GetEntityDetailsResponse<T> GetDetails(GetEntityDetailsRequest request);
    }
}