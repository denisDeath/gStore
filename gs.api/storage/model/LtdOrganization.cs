using System.ComponentModel.DataAnnotations;

namespace gs.api.storage.model
{
    public class LtdOrganization : Organization
    {
        [MaxLength(50)]
        public string ShortName { get; set; }

        /// <summary>
        /// кпп
        /// </summary>
        [MaxLength(50)]
        public string Kpp { get; set; }
    }
}