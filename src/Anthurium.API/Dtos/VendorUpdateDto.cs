using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Dtos
{
    public class VendorUpdateDto
    {
        [Key]
        public int VendorId { get; set; }

        [Required]
        [MaxLength(100)]
        public string VendorName { get; set; }

        [Required]
        [MaxLength(50)]
        public string VendorCode { get; set; }


        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = true;
    }
}
