using Anthurium.API.Dtos;
using Anthurium.Shared.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            //source->target
            //api get,post,update(delete)
            CreateMap<Item, ItemReadDto>();

            CreateMap<ItemCreateDto, Item>()
            .ForMember(destination => destination.ItemId, source => source.Ignore());

            CreateMap<ItemUpdateDto, Item>()
                .ForMember(destination => destination.ItemId, source => source.Ignore())
                .ForMember(destination => destination.DateCreated, source => source.Ignore())
                .ForMember(destination => destination.IsActive, source => source.Ignore());

            CreateMap<Item, ItemUpdateDto>();

        }
    }
}
