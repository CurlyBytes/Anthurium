using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Anthurium.API.Dtos
{
    public class ItemUpdateDto
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
        public double Margin { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int VendorId { get; set; }

        public VendorUpdateDto Vendor { get; set; }

        [Required]
        public int WarehouseId { get; set; }

        public WarehouseUpdateDto Warehouse { get; set; }

        [Required]
        public bool IsLocalMaterial { get; set; }

        [Required]
        public DateTime WarrantyDate { get; set; }


        public ICollection<DeliveryReceiptDetailsUpdateDto> DeliveryRecieptDetails { get; set; }
        public ICollection<JobQuotationDetailsUpdateDto> JobQuotationDetails { get; set; }



        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; }
    }
}