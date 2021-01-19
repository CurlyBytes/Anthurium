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

        public string CompanyName { get; set; }

        public string CompanyAddress { get; set; }

        public string ContactPerson { get; set; }

        public string ContactNumber { get; set; }

        public string TimeStarted { get; set; }

        public string  TimeEnded { get; set; }

        public int TotalHours { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public bool IsActive { get; set; }

        public ICollection<ClientInformation> ClientInformations { get; set; }

        public JobOrderDescriptionOfWork JobOrderDescriptionOfWork { get; set; }

    }
}
