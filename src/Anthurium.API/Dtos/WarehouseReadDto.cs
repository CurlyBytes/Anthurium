using Anthurium.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Dtos
{
    public class WarehouseReadDto
    {
        [Key]
        public int WarehouseId { get; set; }

        [Required]
        [MaxLength(100)]
        public string WarehouseName { get; set; }

        [Required]
        [MaxLength(50)]
        public string WarehouseCode { get; set; }

        public ICollection<Item> Item { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateUpdated { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
