using System;
using System.ComponentModel.DataAnnotations;

namespace Anthurium.Shared.Models
{
    public class JobQuotationDetails
    {
        [Key]
        public int JobQuotationDetailsId { get; set; }

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
        public bool IsAlreadyPurchaseOrder { get; set; }


        [MaxLength(75)]
        public string PurchaseOrderCode { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateUpdated { get; set; } 

        [Required]
        public bool IsActive { get; set; }





        public Item Item { get; set; }
        public JobQuotation JobQuotation { get; set; }

 

    }
}