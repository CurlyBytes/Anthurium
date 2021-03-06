using Anthurium.API.Dtos;
using Anthurium.Shared.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Profiles
{
    public class VendorProfile : Profile
    {
        public VendorProfile()
        {
            //source->target
            //api get,post,update(delete)
            CreateMap<Vendor, VendorReadDto>();
            CreateMap<VendorReadDto, VendorUpdateDto>();
            CreateMap<VendorCreateDto, Vendor>()
            .ForMember(destination => destination.VendorId, source => source.Ignore());

            CreateMap<VendorUpdateDto, Vendor>()
                .ForMember(destination => destination.VendorId, source => source.Ignore())
                .ForMember(destination => destination.DateCreated, source => source.Ignore())
                .ForMember(destination => destination.IsActive, source => source.Ignore());

            CreateMap<Vendor, VendorUpdateDto>();

        }
    }
}
