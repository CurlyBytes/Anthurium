﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Anthurium.API.Dtos
{
    public class JobQuotationReadDto
    {
        [Key]
        public int JobQuotationId { get; set; }
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
        [MaxLength(400)]
        public string Description { get; set; }


        [Required]
        public double OverallCost { get; set; }

        [Required]
        public bool HasCustomerAlreadyAgreed { get; set; }


        [Required]
        public int ClientInformationId { get; set; }

        public ICollection<JobQuotationDetailsReadDto> JobQuotationDetails { get; set; }

        public ClientInformationReadDto ClientInformation { get; set; }

        public DateTime DateUpdated { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsActive { get; set; }
    }
}