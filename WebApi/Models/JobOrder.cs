using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class JobOrder
    {
        [Key]
        public int Id { get; set; }

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
        public string  TimeEnded { get; set; }

        public List<JobOrderDescriptionOfWork> JobOrderDescriptionOfWork { get; set; } = new List<JobOrderDescriptionOfWork>();

        [Required]
        public int TotalHours { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateUpdated { get; set; }

        [Required]
        public bool IsActive { get; set; }


        

    }
}
