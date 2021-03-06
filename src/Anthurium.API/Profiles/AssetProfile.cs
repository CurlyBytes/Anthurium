using Anthurium.API.Dtos;
using Anthurium.Shared.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Profiles
{
    public class AssetProfile : Profile
    {
        public AssetProfile()
        {
            //source->target
            //api get,post,update(delete)
            CreateMap<Asset, AssetReadDto>();

            CreateMap<AssetCreateDto, Asset>()
            .ForMember(destination => destination.AssetId, source => source.Ignore());

            CreateMap<AssetUpdateDto, Asset>()
                .ForMember(destination => destination.AssetId, source => source.Ignore())
                .ForMember(destination => destination.DateCreated, source => source.Ignore())
                .ForMember(destination => destination.IsActive, source => source.Ignore());

            CreateMap<Asset, AssetUpdateDto>();

        }
    }
}
