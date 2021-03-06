using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Dtos
{
    public class JobQuotationChangeCreate
    {


        [Required]
        public int ClientInformationId { get; set; }

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


        [Required]
        [MaxLength(200)]
        [EmailAddress]
        public string ContactEmailAddress { get; set; }


        public DateTime DateUpdated { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsActive { get; set; }
    }
}
