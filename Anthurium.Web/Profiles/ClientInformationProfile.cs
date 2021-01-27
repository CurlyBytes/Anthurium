﻿using Anthurium.Shared.Dtos;
using Anthurium.Shared.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Anthurium.Web.Profiles
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
