using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Anthurium.API.Dtos
{
    public class JobQuotationUpdateDto
    {
        [Key]
        public int JobQuotationId { get; set; }



        [Required]
        [MaxLength(400)]
        public string Description { get; set; }



        [Required]
        public double OverallCost { get; set; }


        public ICollection<JobQuotationDetailsUpdateDto> JobQuotationDetails { get; set; }

        [Required]
        public int ClientInformationId { get; set; }

        public ClientInformationUpdateDto ClientInformation { get; set; }
        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;

    }
}