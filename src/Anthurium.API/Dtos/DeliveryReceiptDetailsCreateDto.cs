using System;
using System.ComponentModel.DataAnnotations;

namespace Anthurium.API.Dtos
{
    public class DeliveryReceiptDetailsCreateDto
    {
      
        public int DeliveryReceiptId { get; set; }

        public DeliveryReceiptCreateDto DeliveryReceipt { get; set; }

        [Required]
        public int Quantity { get; set; }

        public ItemCreateDto Item { get; set; }

        [Required]
        public int ItemId { get; set; }

        [Required]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;

        [Required]
        public bool IsActive { get; set; } = true;
    }
}