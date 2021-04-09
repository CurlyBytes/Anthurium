using Anthurium.API.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Anthurium.API.Dtos {
  public class ItemReadDto {
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

    public string QRCode {
      get;
      set;
    }
    // public string QRCode   // property
    //{
    //    get { return QRCode; }   // get method
    //    set
    //    {

    //        QRCode = QRCodeEnrpytion.GenerateQRCode(ItemName); ;

    //    }  // set method
    //}
    [Required]
    public int WarehouseId {
      get;
      set;
    }

    public WarehouseReadDto Warehouse {
      get;
      set;
    }

    public ICollection<DeliveryReceiptDetailsReadDto> DeliveryReceiptDetails {
      get;
      set;
    }
    public ICollection<JobQuotationDetailsReadDto> JobQuotationDetails {
      get;
      set;
    }
    public DateTime DateCreated {
      get;
      set;
    }

    public DateTime DateUpdated {
      get;
      set;
    }

    public bool IsActive {
      get;
      set;
    }
  }
}