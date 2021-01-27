﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anthurium.Shared.Dtos;
using Anthurium.Shared.Models;
using AutoMapper;

namespace Anthurium.Web.Profiles
{
    public class JobOrderProfile : Profile
    {
        public JobOrderProfile()
        {
            //source->target
    

            CreateMap<JobOrder, JobOrderReadDto>();
            CreateMap<JobOrderCreateDto, JobOrder>();
            CreateMap<JobOrderUpdateDto, JobOrder>();
            CreateMap<JobOrder, JobOrderUpdateDto>();
        }
    }
}
