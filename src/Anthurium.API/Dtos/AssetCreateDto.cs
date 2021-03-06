﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Dtos
{
    public class AssetCreateDto
    {
   

        [Required]
        public int ClientInformationId { get; set; }


        public ClientInformationCreateDto ClientInformation { get; set; }
        [Required]
        public int VendorId { get; set; }

        public VendorCreateDto Vendor { get; set; }
        [Required]
        public int ItemId { get; set; }


        public ItemCreateDto Item { get; set; }



        [Required]
        public DateTime WarrantyDate { get; set; }

        [Required]
        [MaxLength(200)]
        public string SerialNumber { get; set; }
        [Required]
        public DateTime DateRecieve { get; set; }

        [Required]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
