using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Dtos
{
    public class WarehouseUpdateDto
    {
        [Key]
        public int WarehouseId { get; set; }

        [Required]
        [MaxLength(100)]
        public string WarehouseName { get; set; }

        [Required]
        [MaxLength(50)]
        public string WarehouseCode { get; set; }

        public ICollection<ItemUpdateDto> Item { get; set; }


        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } 
    }
}
