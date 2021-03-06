﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Anthurium.API.Dtos
{
    public class JobQuotationUpdateDto
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
        [MaxLength(300)]
        public string ContactPerson { get; set; }

        [Required]
        [MaxLength(20)]

        public string ContactNumber { get; set; }


        [Required]
        [MaxLength(200)]
        [EmailAddress]
        public string ContactEmailAddress { get; set; }

        [Required]
        public double OverallCost { get; set; }

        [Required]
        public bool HasCustomerAlreadyAgreed { get; set; }
        public ICollection<JobQuotationDetailsUpdateDto> JobQuotationDetails { get; set; }

        [Required]
        public int ClientInformationId { get; set; }

        public ClientInformationUpdateDto ClientInformation { get; set; }
        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;

    }
}