using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace gs.api.storage.model.resellers.dicts
{
    [DataContract]
    public class Store : BaseDbWithOwner
    {
        [UsedImplicitly]
        public Store() { }
        
        public Store(long ownerId, long id, string name, string description, string address, bool isShop): base(ownerId)
        {
            Id = id;
            Name = name;
            Description = description;
            Address = address;
            IsShop = isShop;
        }

        public Store(long ownerId): base(ownerId)
        {
        }
        
        /// <summary>
        /// Идентификатор магазина.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public long Id { get; set; }

        /// <summary>
        /// Название магазина.
        /// </summary>
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        /// <summary>
        /// Адрес магазина.
        /// </summary>
        public string Address { get; set; }
        
        /// <summary>
        /// Является ли склад магазином.
        /// </summary>
        public bool IsShop { get; set; }
        
        public override void UpdateFieldsFrom(BaseDbEntity entity)
        {
            var source = (Store) entity;
            if (source == null)
                throw new InvalidOperationException($"Parameter entity must be of {nameof(Store)} type.");

            Id = source.Id;
            Name = source.Name;
            Description = source.Description;
            Address = source.Address;
            IsShop = source.IsShop;
        }
    }
}