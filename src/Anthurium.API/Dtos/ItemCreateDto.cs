using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Anthurium.API.Dtos
{
    public class ItemCreateDto
    {
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

        public VendorCreateDto Vendor { get; set; }

        [Required]
        public int WarehouseId { get; set; }

        public WarehouseCreateDto Warehouse { get; set; }

        [Required]
        public bool IsLocalMaterial { get; set; }

        [Required]
        public DateTime WarrantyDate { get; set; }


        public ICollection<DeliveryReceiptDetailsCreateDto> DeliveryRecieptDetails { get; set; }
        public ICollection<JobQuotationDetailsCreateDto> JobQuotationDetails { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;


        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = true;
    }
}