using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Anthurium.Shared.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        [MaxLength(50)]
        public string ItemType { get; set; }

        [Required]
        [MaxLength(50)]
        public string ItemGroup { get; set; }
        [Required]
        [MaxLength(50)]
        public string ItemCode { get; set; }

        [Required]
        public DateTime ItemName { get; set; }

        [Required]
        public decimal Margin { get; set; }

        [Required]
        [MaxLength(50)]
        public decimal Price { get; set; }


        public Vendor VendorId { get; set; }

        [Required]
        public bool IsLocalMaterial { get; set; }

        [Required]
        public DateTime WarrantyDate { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateUpdated { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
