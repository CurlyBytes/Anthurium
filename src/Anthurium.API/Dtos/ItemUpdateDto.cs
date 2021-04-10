using Anthurium.API.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Anthurium.API.Dtos {
  public class ItemUpdateDto {


    [Key]
    public int ItemId {
      get;
      set;
    }

    [Required]
    [MaxLength(50)]
    public string ItemType {
      get;
      set;
    }

    [Required]
    [MaxLength(50)]
    public string ItemGroup {
      get;
      set;
    }
    [Required]
    [MaxLength(50)]
    public string ItemCode {
      get;
      set;
    }

    [Required]
    [MaxLength(150)]
    public string ItemName {
      get;
      set;
    }

     
    [Required]
    public int WarehouseId {
      get;
      set;
    }

    public WarehouseUpdateDto Warehouse {
      get;
      set;
    }

    public ICollection<DeliveryReceiptDetailsUpdateDto> DeliveryReceiptDetails {
      get;
      set;
    }
    public ICollection<JobQuotationDetailsUpdateDto> JobQuotationDetails {
      get;
      set;
    }

    public DateTime DateUpdated {
      get;
      set;
    }
    = DateTime.UtcNow;

    public bool IsActive {
      get;
      set;
    }
  }
}
