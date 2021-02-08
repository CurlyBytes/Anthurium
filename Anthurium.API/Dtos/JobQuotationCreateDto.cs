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



        public DateTime DateCreated { get; set; } = DateTime.UtcNow;


        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;


        [Required]
        public int ClientInformationId { get; set; }

        public ClientInformationReadDto ClientInformation { get; set; }

        public ICollection<JobQuotationDetailsReadDto> JobQuotationDetails { get; set; }

        public bool IsActive { get; set; } = true;

     
    }
}
