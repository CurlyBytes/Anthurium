using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class JobOrderDescriptionOfWorkReadDto
    {
   
        public string JobOrderTypeOfWOrk { get; set; }


        public ICollection<JobOrderReadDto> JobOrders { get; set; }
    }
}
