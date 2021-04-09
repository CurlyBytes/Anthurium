using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Anthurium.API.Dtos
{
public class DeliveryReceiptReadDto
{
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

    public ClientInformationReadDto ClientInformation {
        get;
        set;
    }

    [Required]
    public int JobQuotationId {
        get;
        set;
    }

    public JobQuotationReadDto JobQuotation {
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
    public ICollection<JobQuotationReadDto> JobQuotationDetails {
        get;
        set;
    }

    public ICollection<DeliveryReceiptDetailsReadDto> DeliveryReceiptDetails {
        get;
        set;
    }
}
}