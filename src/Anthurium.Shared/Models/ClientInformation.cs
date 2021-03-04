using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.Shared.Models
{
    public class ClientInformation
    {
        [Key]
        public int ClientInformationId { get; set; }

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
        [MaxLength(200)]
        [EmailAddress]
        public string ContactEmailAddress { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateUpdated { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public ICollection<JobOrder> JobOrder { get; set; }

        public ICollection<JobQuotation> JobQuotation { get; set; }

        public ICollection<Asset> Asset { get; set; }

        public ICollection<DeliveryReceipt> DeliveryReceipt { get; set; }
    }
}
