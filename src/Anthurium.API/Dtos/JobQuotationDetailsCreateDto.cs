using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Dtos
{
    public class JobQuotationDetailsCreateDto
    {


        [Required]
        public int JobQuotationId { get; set; }

        [Required]
        public int ItemId { get; set; }

        [Required]
        [MaxLength(150)]
        public string ItemName { get; set; }
        [Required]
        public double MarginPrice { get; set; }

        [Required]
        public double OriginalPrice { get; set; }

        [Required]
        public double SellingPrice { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public double TotalCost { get; set; }
        [Required]
        public bool IsAlreadyPurchaseOrder { get; set; } = false;


        [MaxLength(75)]
        public string PurchaseOrderCode { get; set; }

        [Required]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;

        [Required]
        public bool IsActive { get; set; } = true;





        public ItemCreateDto Item { get; set; }
        public JobQuotationCreateDto JobQuotation { get; set; }

    }
}
