using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.stores
{
    [DataContract]
    public class StoreInfo
    {
        public StoreInfo(int id, int name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
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
        public int Name { get; }
        
        /// <summary>
        /// Адрес магазина.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Address { get; }
    }
}