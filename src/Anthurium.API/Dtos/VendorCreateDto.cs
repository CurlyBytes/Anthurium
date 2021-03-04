using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Dtos
{
    public class VendorCreateDto
    {

        [Required]
        [MaxLength(100)]
        public string VendorName { get; set; }

        [Required]
        [MaxLength(50)]
        public string VendorCode { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;


        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = true;

        public ICollection<ItemCreateDto> Item { get; set; }
    }
}
