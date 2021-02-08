using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.Shared.Models
{
    public class JobOrder
    {
        [Key]
        public int JobOrderId { get; set; }

        [Required]
        [MaxLength(250)]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(450)]
        public string CompanyAddress { get; set; }


        [Required]
        [MaxLength(300)]
        public string ContactPerson { get; set; }

        [Required]
        [MaxLength(20)]

        public string ContactNumber { get; set; }

        [Required]
        public DateTime TimeStarted { get; set; }

        [Required]
        public DateTime TimeEnded { get; set; }

        // public List<JobOrderDescriptionOfWork> JobOrderDescriptionOfWork { get; set; } = new List<JobOrderDescriptionOfWork>();

        [Required]
        public int TotalHours { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateUpdated { get; set; } 

        [Required]
        public bool IsActive { get; set; } 

        [Required]
        public int ClientInformationId { get; set; }
        public ClientInformation ClientInformation { get; set; }
        public ICollection<JobOrderDescriptionOfWork> JobOrderDescriptionOfWork { get; set; }

    }
}
