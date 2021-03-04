using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Dtos
{
    public class AssetUpdateDto
    {
        [Key]
        public int AssetId { get; set; }

        [Required]
        public int ClientInformationId { get; set; }

        [Required]
        public ClientInformationUpdateDto ClientInformation { get; set; }

        [Required]
        public int ItemId { get; set; }

        [Required]
        public ItemUpdateDto Item { get; set; }

        [Required]
        [MaxLength(200)]
        public string SerialNumber { get; set; }
        [Required]
        public DateTime DateRecieve { get; set; }

     
        [Required]
        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
