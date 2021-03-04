using System;
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

        [Required]
        public ClientInformationCreateDto ClientInformation { get; set; }

        [Required]
        public int ItemId { get; set; }

        [Required]
        public ItemCreateDto Item { get; set; }

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
