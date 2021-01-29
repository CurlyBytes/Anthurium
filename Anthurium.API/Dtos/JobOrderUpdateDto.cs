﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Dtos
{
    public class JobOrderUpdateDto
    {
           
        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string CompanyAddress { get; set; }

        [Required]
        public string ContactPerson { get; set; }

        [Required]
        public string ContactNumber { get; set; }

        [Required]
        public DateTime TimeStarted { get; set; }

        [Required]
        public DateTime TimeEnded { get; set; }

        [Required]
        public int TotalHours { get; set; }

        [Required]
        public int ClientInformationId { get; set; }
    }
}
