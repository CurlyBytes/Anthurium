using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class JobOrderUpdateDto
    {
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
        public string TimeStarted { get; set; }

        [Required]
        public string TimeEnded { get; set; }

        [Required]
        public int TotalHours { get; set; }
    }
}
