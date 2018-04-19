using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JetBrains.Annotations;

namespace gs.api.storage.model.resellers.dicts
{
    public class GoodCategory : BaseDbWithOwner
    {
        [UsedImplicitly]
        public GoodCategory() { }
        
        public GoodCategory(long ownerId, long id, string name, string description, string imageUrl)
            : base(ownerId)
        {
            Id = id;
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
        }
        
        public GoodCategory(long ownerId): base(ownerId)
        {
        }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string ImageUrl { get; set; }
        
        public override void UpdateFieldsFrom(BaseDbEntity entity)
        {
            var source = (GoodCategory) entity;
            if (source == null)
                throw new InvalidOperationException($"Parameter entity must be of {nameof(GoodCategory)} type.");
            
            Name = source.Name;
            Description = source.Description;
            ImageUrl = source.ImageUrl;
        }
    }
}