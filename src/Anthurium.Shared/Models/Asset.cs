using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Anthurium.Shared.Models
{
    public class Asset
    {
        [Key]
        public int AssetId { get; set; }

        [Required]
        public int ClientInformationId { get; set; }


        public ClientInformation ClientInformation { get; set; }
        [Required]
        public int VendorId { get; set; }

        public Vendor Vendor { get; set; }

        [Required]
        public int ItemId { get; set; }

        [Required]
        public Item Item { get; set; }

        [Required]
        [MaxLength(200)]
        public string SerialNumber { get; set; }
        [Required]
        public DateTime DateRecieve { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateUpdated { get; set; }

        [Required]
        public bool IsActive { get; set; }

    }
}
