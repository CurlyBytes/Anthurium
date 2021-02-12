using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Anthurium.Shared.Models
{
    public class JobQuotation
    {
        [Key]
        public int JobQuotationId { get; set; }

        [Required]
        [MaxLength(250)]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(450)]
        public string CompanyAddress { get; set; }

        [Required]
        [MaxLength(400)]
        public string Description { get; set; }

        [Required]
        public double OverallCost { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateUpdated { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int ClientInformationId { get; set; }

        public ClientInformation ClientInformation { get; set; }

        public ICollection<JobQuotationDetails> JobQuotationDetails { get; set; }
    }
}
