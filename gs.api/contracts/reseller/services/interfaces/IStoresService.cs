using gs.api.contracts.reseller.dto.exceptions;
using gs.api.contracts.reseller.dto.stores;

namespace gs.api.contracts.reseller.services.interfaces
{
    /// <summary>
    /// Методы для работы со справочником магазинов.
    /// </summary>
    [Throws(typeof(TokenExpiredException))]
    [Throws(typeof(UnauthorizedException))]
    public interface IStoresService
    {
        /// <summary>
        /// Получить список магазинов организации.
        /// </summary>
        GetStoresResponse GetStores();

        /// <summary>
        /// Проверка, существует ли магазин с указанным именем.
        /// </summary>
        bool IsStoreNameExists(IsStoreNameExistsRequest request);
        
        /// <summary>
        /// Добавить магазин.
        /// </summary>
        [Throws(typeof(StoreAlreadyExistsException))]
        void AddStore(AddStoreRequest request);
    }
}