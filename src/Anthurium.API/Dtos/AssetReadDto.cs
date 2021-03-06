using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Dtos
{
    public class AssetReadDto
    {
        [Key]
        public int AssetId { get; set; }

        [Required]
        public int ClientInformationId { get; set; }


        public ClientInformationReadDto ClientInformation { get; set; }
        [Required]
        public int VendorId { get; set; }

        public VendorReadDto Vendor { get; set; }
        [Required]
        public int ItemId { get; set; }

        [Required]
        public ItemReadDto Item { get; set; }


        [Required]
        public DateTime WarrantyDate { get; set; }
        [Required]
        [MaxLength(200)]
        public string SerialNumber { get; set; }
        [Required]
        public DateTime DateRecieve { get; set; }

        [Required]
        public DateTime DateCreated { get; set; } 

        public DateTime DateUpdated { get; set; }

        [Required]
        public bool IsActive { get; set; } 
    }
}
