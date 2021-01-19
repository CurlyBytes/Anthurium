using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class JobOrderReadDto
    {


        [Required]
        public string ContactPerson { get; set; }

        [Required]
        public string ContactNumber { get; set; }

        [Required]
        public string TimeStarted { get; set; }

        [Required]
        public string TimeEnded { get; set; }

        [Required]
        public int TotalHours { get; set; }



        public ICollection<ClientInformationReadDto> ClientInformations { get; set; }

        public JobOrderDescriptionOfWorkReadDto JobOrderDescriptionOfWork { get; set; }
    }
}
