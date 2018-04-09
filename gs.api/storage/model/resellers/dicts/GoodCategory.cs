﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JetBrains.Annotations;

namespace gs.api.storage.model.resellers.dicts
{
    public class GoodCategory : BaseDbEntity
    {
        [UsedImplicitly]
        public GoodCategory() { }
        
        public GoodCategory(long id, string name, string description, string imageUrl)
        {
            Id = id;
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
        }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public long Id { get; set; }

        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string ImageUrl { get; set; }
        
        public override void UpdateFieldsFrom(BaseDbEntity entity)
        {
            var source = (GoodCategory) entity;
            Name = source.Name;
            Description = source.Description;
            ImageUrl = source.ImageUrl;
        }
    }
}