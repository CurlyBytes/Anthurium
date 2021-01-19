using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dtos;

namespace WebApi.Profiles
{
    public class JobOrderDescriptionOfWork : Profile
    {
        public JobOrderDescriptionOfWork()
        {
            //source->target
            CreateMap<JobOrderDescriptionOfWork, JobOrderDescriptionOfWorkReadDto>();
            CreateMap<JobOrderDescriptionOfWorkCreateDto, JobOrderDescriptionOfWork>();
            CreateMap<JobOrderDescriptionOfWorkUpdateDto, JobOrderDescriptionOfWork>();
            CreateMap<JobOrderDescriptionOfWork, JobOrderDescriptionOfWorkUpdateDto>();
        }
    }
}
