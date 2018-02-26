using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace gs.api.storage.model
{
    [DataContract]
    public class Organization
    {
        public Organization(long id, string name)
        {
            Id = id;
            Name = name;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        [DataMember(IsRequired = true)]
        public long Id { get; set; }

        [DataMember(IsRequired = true)]
        [Required, MinLength(3), MaxLength(50)]
        public string Name { get; set; }
    }
}