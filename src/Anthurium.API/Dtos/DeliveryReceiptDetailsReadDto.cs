﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Anthurium.API.Dtos
{
    public class DeliveryReceiptDetailsReadDto
    {
        [Key]
        public int DeliveryReceiptDetailsId { get; set; }


        public int DeliveryReceiptId { get; set; }

        public DeliveryReceiptReadDto DeliveryReceipt { get; set; }

        [Required]
        public int Quantity { get; set; }

        public ItemReadDto Item { get; set; }

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