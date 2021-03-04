using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Anthurium.Shared.Models
{
    public class Warehouse
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
