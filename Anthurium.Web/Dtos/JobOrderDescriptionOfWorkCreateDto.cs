﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.Web.Dtos
{
    public class JobOrderDescriptionOfWorkCreateDto
    {
        [Required]
        public string JobOrderTypeOfWOrk { get; set; }
    }
}
