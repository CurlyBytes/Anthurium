using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Dtos
{
public class DeliveryReceiptUpdateDto
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

    public ClientInformationUpdateDto ClientInformation {
        get;
        set;
    }

    [Required]
    public int JobQuotationId {
        get;
        set;
    }

    public JobQuotationUpdateDto JobQuotation {
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
    public ICollection<JobQuotationUpdateDto> JobQuotationDetails {
        get;
        set;
    }

    public ICollection<DeliveryReceiptDetailsUpdateDto> DeliveryReceiptDetails {
        get;
        set;
    }
}
}
