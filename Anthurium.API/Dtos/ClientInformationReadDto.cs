﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Anthurium.Shared.Models;

namespace Anthurium.API.Dtos
{
    public class ClientInformationReadDto
    {
        [Key]
        public int ClientInformationId { get; set; }

        [Required]
        [MaxLength(250)]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(450)]
        public string CompanyAddress { get; set; }

        public ICollection<JobOrder> JobOrder { get; set; }

        public ICollection<JobQuotation> JobQuotation { get; set; }
    }
}
