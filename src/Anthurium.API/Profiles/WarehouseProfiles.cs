using Anthurium.API.Dtos;
using Anthurium.Shared.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Profiles
{
    public class WarehouseProfiles : Profile
    {
        public WarehouseProfiles()
        {
            //source->target
            //api get,post,update(delete)
            CreateMap<Warehouse, WarehouseReadDto>();
            CreateMap<WarehouseReadDto, WarehouseUpdateDto>();

            CreateMap<WarehouseCreateDto, Warehouse>()
            .ForMember(destination => destination.WarehouseId, source => source.Ignore());

            CreateMap<WarehouseUpdateDto, Warehouse>()
                .ForMember(destination => destination.WarehouseId, source => source.Ignore())
                .ForMember(destination => destination.DateCreated, source => source.Ignore())
                .ForMember(destination => destination.IsActive, source => source.Ignore());

            CreateMap<Warehouse, WarehouseUpdateDto>();

            //dropdown
            CreateMap<WarehouseReadDto, ItemCreateDto>()
                           .ForMember(dest => dest.WarehouseId, opt => opt.MapFrom(src => src.WarehouseId));
            CreateMap<WarehouseReadDto, ItemUpdateDto>()
                       .ForMember(dest => dest.WarehouseId, opt => opt.MapFrom(src => src.WarehouseId));

        }

    }
}
