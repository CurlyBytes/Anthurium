using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Anthurium.API.Dtos
{
    public class JobQuotationUpdateDto
    {
        [Key]
        public int JobQuotationId { get; set; }

        [MaxLength(250)]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(450)]
        public string CompanyAddress { get; set; }


        [Required]
        [MaxLength(300)]
        public string ContactPerson { get; set; }

        [Required]
        [MaxLength(20)]
        public string ContactNumber { get; set; }

       public DateTime DateUpdated { get; set; } = DateTime.UtcNow;


        [Required]
        public int ClientInformationId { get; set; }

        public ClientInformationReadDto ClientInformation { get; set; }

        public ICollection<JobQuotationDetailsReadDto> JobQuotationDetails { get; set; }

    }
}