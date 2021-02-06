using Anthurium.API.Dtos;
using Anthurium.Shared.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Anthurium.API.Profiles
{
    public class ClientInformationProfile : Profile
    {
        public ClientInformationProfile()
        {
            //source->target
            //api get,post,update(delete)
            CreateMap<ClientInformation, ClientInformationReadDto>();
            CreateMap<ClientInformationCreateDto, ClientInformation>();
            CreateMap<ClientInformationUpdateDto, ClientInformation>();
            CreateMap<ClientInformation, ClientInformationUpdateDto>();

            //web razor comp on edit clientinformation
            CreateMap<ClientInformationReadDto, ClientInformationUpdateDto>();

            //web razor comp on add joborder
            CreateMap<ClientInformationReadDto, JobOrderChangeCreate>()
             .ForMember(dest => dest.ClientInformationId, opt => opt.MapFrom(src => src.ClientInformationId)); 

            CreateMap<JobOrderChangeCreate, JobOrderCreateDto>();
            CreateMap<JobOrderChangeCreate, JobOrderUpdateDto>();

            //CreateMap<Object, List<ClientInformationReadDto>>();
        }

       
    }
}
