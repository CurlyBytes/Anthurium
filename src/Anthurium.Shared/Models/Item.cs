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
        [MaxLength(150)]
        public string ItemName { get; set; }

  


        [Required]
        public int WarehouseId { get; set; }

        public Warehouse Warehouse { get; set; }

        [Required]
        public bool IsLocalMaterial { get; set; }

        [Required]
        public DateTime WarrantyDate { get; set; }


        public ICollection<DeliveryReceiptDetails> DeliveryRecieptDetails { get; set; }
        public ICollection<JobQuotationDetails> JobQuotationDetails { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateUpdated { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
