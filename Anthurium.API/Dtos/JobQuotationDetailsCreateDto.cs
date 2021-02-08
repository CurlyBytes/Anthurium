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


        [Required]
        [MaxLength(400)]
        public string Description { get; set; }

        [Required]
        public double Cost { get; set; }

        [Required]
        public double TotalCost { get; set; }

        [Required]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;

        [Required]
        public int JobQuotationId { get; set; }

        public JobQuotationReadDto JobQuotation { get; set; }
        [Required]
        public bool IsActive { get; set; } = true;
    }
}
