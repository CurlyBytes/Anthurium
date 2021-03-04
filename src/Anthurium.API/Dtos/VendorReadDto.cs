using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Dtos
{
    public class VendorReadDto
    {
        [Key]
        public int VendorId { get; set; }
        [Required]
        [MaxLength(100)]
        public string VendorName { get; set; }

        [Required]
        [MaxLength(50)]
        public string VendorCode { get; set; }

        public DateTime DateCreated { get; set; }


        public DateTime DateUpdated { get; set; } 

        public bool IsActive { get; set; } = true;

        public ICollection<ItemReadDto> Item { get; set; }
    }
}
