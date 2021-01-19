using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Profiles
{
    public class ClientInformationProfile : Profile
    {
        public ClientInformationProfile()
        {
            //source->target
            CreateMap<ClientInformation, ClientInformationReadDto>();
            CreateMap<ClientInformationCreateDto, ClientInformation>();
            CreateMap<ClientInformationUpdateDto, ClientInformation>();
            CreateMap<ClientInformation, ClientInformationUpdateDto>();
        }
    }
}
