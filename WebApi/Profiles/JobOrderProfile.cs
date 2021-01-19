using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dtos;
using WebApi.Models;
using AutoMapper;

namespace WebApi.Profiles
{
    public class JobOrderProfile : Profile
    {
        public JobOrderProfile()
        {
            //source->target
            CreateMap<JobOrder, JobOrderReadDto>();
            CreateMap<JobOrderReadDto, JobOrder>();
            CreateMap<JobOrderUpdateDto, JobOrder>();
            CreateMap<JobOrder, JobOrderUpdateDto>();
        }
    }
}
