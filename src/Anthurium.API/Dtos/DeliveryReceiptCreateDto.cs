using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Dtos
{
    public class DeliveryReceiptCreateDto
    {
   

   

        public ClientInformationCreateDto ClientInformation { get; set; }

        [Required]
        public int JobQuotationId { get; set; }

        public JobQuotationCreateDto JobQuotation { get; set; }

        [Required]
        [MaxLength(250)]
        public string Remarks { get; set; }

        [Required]
        public DateTime DateRecieve { get; set; }

        [Required]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
