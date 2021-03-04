using System;
using System.ComponentModel.DataAnnotations;

namespace Anthurium.API.Dtos
{
    public class DeliveryReceiptDetailsUpdateDto
    {
        [Key]
        public int DeliveryReceiptDetailsId { get; set; }


        public int DeliveryReceiptId { get; set; }

        public DeliveryReceiptUpdateDto DeliveryReceipt { get; set; }

        [Required]
        public int Quantity { get; set; }

        public ItemUpdateDto Item { get; set; }

        [Required]
        public int ItemId { get; set; }



        [Required]
        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;

        [Required]
        public bool IsActive { get; set; } = true;
    }
}