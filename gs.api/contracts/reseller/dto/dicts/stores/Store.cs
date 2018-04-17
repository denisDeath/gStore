using System.Runtime.Serialization;
using gs.api.contracts.reseller.dto.common;

namespace gs.api.contracts.reseller.dto.dicts.stores
{
    [DataContract]
    public class Store : BaseDtoEntity
    {
        public Store(long id, string name, string description, string address, bool isShop)
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
        public override long Id { get; set; }
        
        /// <summary>
        /// Название магазина.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Name { get; set; }
        
        [DataMember(IsRequired = true)]
        public string Description { get; set; }
        
        /// <summary>
        /// Адрес магазина.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Address { get; set; }
        
        /// <summary>
        /// Является ли склад магазином.
        /// </summary>
        [DataMember(IsRequired = true)]
        public bool IsShop { get; set; }
    }
}