using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace gs.api.storage.model.resellers.dicts
{
    [DataContract]
    public class Store
    {
        [UsedImplicitly]
        public Store() { }
        
        public Store(long ownerId, int id, int name, string description, string address, bool isShop)
        {
            Owner = new Organization
            {
                OrganizationId = ownerId
            };
            Id = id;
            Name = name;
            Description = description;
            Address = address;
            IsShop = isShop;
        }

        public Store(long ownerId)
        {
            Owner = new Organization
            {
                OrganizationId = ownerId
            };
        }
        
        [Required, ForeignKey(nameof(Organization.OrganizationId))]
        public Organization Owner { get; set; }
        
        /// <summary>
        /// Идентификатор магазина.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }
        
        /// <summary>
        /// Название магазина.
        /// </summary>
        public int Name { get; set; }
        
        public string Description { get; set; }
        
        /// <summary>
        /// Адрес магазина.
        /// </summary>
        public string Address { get; set; }
        
        /// <summary>
        /// Является ли склад магазином.
        /// </summary>
        public bool IsShop { get; set; }
        
        public void UpdateFieldsFrom(Store source)
        {
            Id = source.Id;
            Name = source.Name;
            Description = source.Description;
            Address = source.Address;
            IsShop = source.IsShop;
        }
    }
}