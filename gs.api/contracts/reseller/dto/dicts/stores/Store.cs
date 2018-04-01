using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.dicts.stores
{
    [DataContract]
    public class Store
    {
        public Store(int id, string name, string description, string address, bool isShop)
        {
            Id = id;
            Name = name;
            Description = description;
            Address = address;
            IsShop = isShop;
        }

        /// <summary>
        /// Идентификатор магазина.
        /// </summary>
        [DataMember(IsRequired = true)]
        public int Id { get; }
        
        /// <summary>
        /// Название магазина.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Name { get; }
        
        [DataMember(IsRequired = true)]
        public string Description { get; }
        
        /// <summary>
        /// Адрес магазина.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Address { get; }
        
        /// <summary>
        /// Является ли склад магазином.
        /// </summary>
        [DataMember(IsRequired = true)]
        public bool IsShop { get; }
    }
}