using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Anthurium.Shared.Models
{
    public class DeliveryReceiptDetails
    {
        [Key]
        public int DeliveryReceiptDetailsId { get; set; }


        public int DeliveryReceiptId { get; set; }

        public DeliveryReceipt DeliveryReceipt { get; set; }

        [Required]
        public int Quantity { get; set; }

        public Item Item { get; set; }

        [Required]
        public int ItemId { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateUpdated { get; set; }

        [Required]
        public bool IsActive { get; set; }


    }
}
