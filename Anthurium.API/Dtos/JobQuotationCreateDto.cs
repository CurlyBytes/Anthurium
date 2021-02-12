using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Dtos
{
    public class JobQuotationCreateDto
    {
       


        [Required]
        [MaxLength(400)]
        public string Description { get; set; }
        [Required]
        [MaxLength(250)]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(450)]
        public string CompanyAddress { get; set; }

        [Required]
        public double OverallCost { get; set; }

        [Required]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public int ClientInformationId { get; set; }

        public ClientInformationCreateDto ClientInformation { get; set; }

        public ICollection<JobQuotationDetailsCreateDto> JobQuotationDetails { get; set; }


    }
}
