using gs.api.contracts.reseller.dto.dicts.stores;

namespace gs.api.contracts.reseller.services.interfaces.dicts
{
    public interface IStoresService
    {
        GetResponse Get();
        AddResponse Add(AddRequest request);
        void Remove(RemoveRequest request);
        void SaveDetails(SaveDetailsRequest request);
        GetDetailsResponse GetDetails(GetDetailsRequest request);
    }
}