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
            CreateMap<ItemReadDto, ItemUpdateDto>();
            CreateMap<ItemCreateDto, Item>()
            .ForMember(destination => destination.ItemId, source => source.Ignore());

            CreateMap<ItemUpdateDto, Item>()
                .ForMember(destination => destination.ItemId, source => source.Ignore())
                .ForMember(destination => destination.DateCreated, source => source.Ignore())
                .ForMember(destination => destination.IsActive, source => source.Ignore());

            CreateMap<Item, ItemUpdateDto>();

 
       

            //CreateMap<ItemReadDto, JobQuotationDetailsCreateDto>()
            //    .ForMember(destination => destination.MarginPrice, source => source.Ignore())
            //    .ForMember(destination => destination.OriginalPrice, source => source.Ignore())
            //    .ForMember(destination => destination.SellingPrice, source => source.Ignore())
            //    .ForMember(destination => destination.Quantity, source => source.Ignore())
            //    .ForMember(destination => destination.TotalCost, source => source.Ignore())
            //    .ForMember(destination => destination.IsAlreadyPurchaseOrder, source => source.Ignore())
            //    .ForMember(destination => destination.PurchaseOrderCode, source => source.Ignore())
            //    .ForMember(destination => destination.IsActive, source => source.Ignore());

            //CreateMap<ItemReadDto, JobQuotationDetailsUpdateDto>();
        }
    }
}
