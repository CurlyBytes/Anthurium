using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.Shared.Dtos
{
    public class JobOrderDescriptionOfWorkReadDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string JobOrderTypeOfWOrk { get; set; }
    }
}
