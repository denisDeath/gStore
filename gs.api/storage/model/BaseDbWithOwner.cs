using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JetBrains.Annotations;

namespace gs.api.storage.model
{
    public abstract class BaseDbWithOwner : BaseDbEntity
    {
        [Required, ForeignKey(nameof(Organization.OrganizationId))]
        public Organization Owner { get; set; }

        [UsedImplicitly]
        public BaseDbWithOwner()
        {
        }
        
        public BaseDbWithOwner(long ownerId)
        {
            Owner = new Organization
            {
                OrganizationId = ownerId
            };
        }
    }
}