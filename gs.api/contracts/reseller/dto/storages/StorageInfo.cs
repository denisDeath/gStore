using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.storages
{
    [DataContract]
    public class StorageInfo
    {
        public StorageInfo(int id, int name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }

        /// <summary>
        /// Идентификатор склада.
        /// </summary>
        [DataMember(IsRequired = true)]
        public int Id { get; }
        
        /// <summary>
        /// Название склада.
        /// </summary>
        [DataMember(IsRequired = true)]
        public int Name { get; }
        
        /// <summary>
        /// Адрес склада.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Address { get; }
    }
}