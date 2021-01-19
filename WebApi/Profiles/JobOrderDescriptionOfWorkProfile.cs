using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Profiles
{
    public class JobOrderDescriptionOfWorkProfile : Profile
    {
        public JobOrderDescriptionOfWorkProfile()
        {
            //source->target
            CreateMap<JobOrderDescriptionOfWork, JobOrderDescriptionOfWorkReadDto>();
            CreateMap<JobOrderDescriptionOfWorkCreateDto, JobOrderDescriptionOfWork>();
            CreateMap<JobOrderDescriptionOfWorkUpdateDto, JobOrderDescriptionOfWork>();
            CreateMap<JobOrderDescriptionOfWork, JobOrderDescriptionOfWorkUpdateDto>();
        }
    }
}
