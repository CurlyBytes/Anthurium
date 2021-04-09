using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Anthurium.Shared.Models {
  public class DeliveryReceipt {
    [Key]
    public int DeliveryReceiptId {
      get;
      set;
    }

    [Required]
    public int ClientInformationId {
      get;
      set;
    }

    public ClientInformation ClientInformation {
      get;
      set;
    }

    [Required]
    public int JobQuotationId {
      get;
      set;
    }

    public JobQuotation JobQuotation {
      get;
      set;
    }

    [Required]
    [MaxLength(250)]
    public string Remarks {
      get;
      set;
    }

    [Required]
    public DateTime DateRecieve {
      get;
      set;
    }

    [Required]
    public DateTime DateCreated {
      get;
      set;
    }

    [Required]
    public DateTime DateUpdated {
      get;
      set;
    }

    [Required]
    public bool IsActive {
      get;
      set;
    }

    public ICollection<DeliveryReceiptDetails> DeliveryReceiptDetails {
      get;
      set;
    }
  }
}
