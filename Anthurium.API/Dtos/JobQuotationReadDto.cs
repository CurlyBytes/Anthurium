using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Anthurium.API.Dtos
{
    public class JobQuotationReadDto
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
        public int ClientInformationReadDto { get; set; }

        public ICollection<JobQuotationDetailsReadDto> JobQuotationDetails { get; set; }

        public ClientInformationReadDto ClientInformation { get; set; }
    }
}