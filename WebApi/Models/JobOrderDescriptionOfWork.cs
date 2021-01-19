using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class JobOrderDescriptionOfWork
    {

        [Key]
        public int Id { get; set; }

        public string JobOrderTypeOfWOrk { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateUpdated { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public ICollection<JobOrder> JobOrders { get; set; }
    }
}
