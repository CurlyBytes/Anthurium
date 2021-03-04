using Anthurium.API.Dtos;
using Anthurium.Shared.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Profiles
{
    public class DeliveryReceiptDetailsProfiles : Profile
    {
        public DeliveryReceiptDetailsProfiles()
        {
            //source->target
            //api get,post,update(delete)
            CreateMap<DeliveryReceiptDetails, DeliveryReceiptDetailsReadDto>();

            CreateMap<DeliveryReceiptDetailsCreateDto, DeliveryReceiptDetails>()
            .ForMember(destination => destination.DeliveryReceiptDetailsId, source => source.Ignore());

            CreateMap<DeliveryReceiptDetailsUpdateDto, DeliveryReceiptDetails>()
                .ForMember(destination => destination.DeliveryReceiptDetailsId, source => source.Ignore())
                .ForMember(destination => destination.DateCreated, source => source.Ignore())
                .ForMember(destination => destination.IsActive, source => source.Ignore());

            CreateMap<DeliveryReceiptDetails, DeliveryReceiptDetailsUpdateDto>();

        }
    }
}
