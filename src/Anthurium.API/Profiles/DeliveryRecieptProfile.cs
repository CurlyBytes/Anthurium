using Anthurium.API.Dtos;
using Anthurium.Shared.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Profiles
{
    public class DeliveryRecieptProfile : Profile
    {
        public DeliveryRecieptProfile()
        {
            //source->target
            //api get,post,update(delete)
            CreateMap<DeliveryReceipt, DeliveryReceiptReadDto>();

            CreateMap<DeliveryReceiptCreateDto, DeliveryReceipt>()
            .ForMember(destination => destination.DeliveryReceiptId, source => source.Ignore());

            CreateMap<DeliveryReceiptUpdateDto, DeliveryReceipt>()
                .ForMember(destination => destination.DeliveryReceiptId, source => source.Ignore())
                .ForMember(destination => destination.DateCreated, source => source.Ignore())
                .ForMember(destination => destination.IsActive, source => source.Ignore());

            CreateMap<DeliveryReceipt, DeliveryReceiptUpdateDto>();

        }

    }
}
