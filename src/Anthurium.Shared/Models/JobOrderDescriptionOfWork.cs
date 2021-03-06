﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.Shared.Models
{
    public class JobOrderDescriptionOfWork
    {

        [Key]
        public int JobOrderDescriptionOfWorkId { get; set; }

        [Required]
        public string JobOrderTypeOfWOrk { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateUpdated { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public JobOrder JobOrder { get; set; }


    }
}
