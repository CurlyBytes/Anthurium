using Anthurium.Shared.Dtos;
using Anthurium.Shared.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Anthurium.Web.Profiles
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
