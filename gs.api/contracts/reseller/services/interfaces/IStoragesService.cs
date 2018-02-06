using gs.api.contracts.reseller.dto.exceptions;
using gs.api.contracts.reseller.dto.storages;

namespace gs.api.contracts.reseller.services.interfaces
{
    /// <summary>
    /// Методы для работы со справочником складов.
    /// </summary>
    [Throws(typeof(TokenExpiredException))]
    [Throws(typeof(UnauthorizedException))]
    public interface IStoragesService
    {
        /// <summary>
        /// Получить список складов организации.
        /// </summary>
        GetStoragesResponse GetStorages();

        /// <summary>
        /// Проверка, существует ли склад с указанным именем.
        /// </summary>
        bool IsStorageNameExists(IsStorageNameExistsRequest request);

        /// <summary>
        /// Добавить склад.
        /// </summary>
        [Throws(typeof(StorageAlreadyExistsException))]
        void AddStorage(AddStorageRequest request);
    }
}