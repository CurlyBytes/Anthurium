﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.Shared.Dtos
{
    public class JobOrderDescriptionOfWorkUpdateDto
    {
        [Required]
        public string JobOrderTypeOfWOrk { get; set; }
    }
}