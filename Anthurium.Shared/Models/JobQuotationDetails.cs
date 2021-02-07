using System;
using System.ComponentModel.DataAnnotations;

namespace Anthurium.Shared.Models
{
    public class JobQuotationDetails
    {
        [Key]
        public int JobQuotationDetailsId { get; set; }

        [Required]
        public int Quantity { get; set; }


        [Required]
        [MaxLength(400)]
        public string Description { get; set; }

        [Required]
        public int Cost { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateUpdated { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int JobQuotationId { get; set; }

        public JobQuotation JobQuotation { get; set; }

    }
}