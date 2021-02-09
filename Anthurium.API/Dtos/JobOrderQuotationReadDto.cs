using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Dtos
{
    public class JobOrderQuotationReadDto
    {

        [Key]
        public int JobQuotationId { get; set; }
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
        public DateTime DateCreated { get; set; }


        [Required]
        public int ClientInformationId { get; set; }

        public ClientInformationReadDto ClientInformation { get; set; }

        public ICollection<JobQuotationDetailsReadDto> JobQuotationDetails { get; set; }
        public DateTime DateUpdated { get; set; }



        public bool IsActive { get; set; }
    }
}
