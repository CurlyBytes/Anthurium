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
        public int Quantity { get; set; }

        public ItemCreateDto Item { get; set; }

        [Required]
        public int ItemId { get; set; }

        [Required]
        [MaxLength(150)]
        public string ItemName { get; set; }
        [Required]
        public double Margin { get; set; }

        [Required]
        public double Price { get; set; }
        [Required]
        public double Cost { get; set; }

        [Required]
        public double TotalCost { get; set; }

        [Required]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;
        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public int JobQuotationId { get; set; }

        public JobQuotationCreateDto JobQuotation { get; set; }

        [Required]
        public bool IsAlreadyPurchaseOrder { get; set; }
    }
}
