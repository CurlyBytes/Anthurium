using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Dtos
{
    public class JobOrderDescriptionOfWorkReadDto
    {
        [Key]
        public int JobOrderDescriptionOfWorkId { get; set; }

        [Required]
        public string JobOrderTypeOfWOrk { get; set; }

        public JobOrderReadDto JobOrder { get; set; }

        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;
    }
}
