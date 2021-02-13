using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Dtos
{
    public class JobOrderDescriptionOfWorkUpdateDto
    {
        [Required] 
        public string JobOrderTypeOfWOrk { get; set; }


        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;

      




        public JobOrderUpdateDto JobOrder { get; set; }
    }
}
