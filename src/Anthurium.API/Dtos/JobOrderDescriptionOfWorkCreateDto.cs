using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Dtos
{
    public class JobOrderDescriptionOfWorkCreateDto
    {
        [Required]
        public string JobOrderTypeOfWOrk { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;


        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = true;
    }
}
