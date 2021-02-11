using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Dtos
{
    public class JobQuotationDetailsUpdateDto
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

        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;

        [Required]
        public int JobQuotationId { get; set; }

        public JobQuotationUpdateDto JobQuotation { get; set; }



        public DateTime DateCreated { get; set; }

        public bool IsActive { get; set; }

    }
}
