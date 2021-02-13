using Anthurium.API.Dtos;
using Anthurium.Shared.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Anthurium.API.Profiles
{
    public class JobOrderDescriptionOfWorkProfile : Profile
    {
        public JobOrderDescriptionOfWorkProfile()
        {
            //source->target
            CreateMap<JobOrderDescriptionOfWork, JobOrderDescriptionOfWorkReadDto>();
            CreateMap<JobOrderDescriptionOfWorkCreateDto, JobOrderDescriptionOfWork>()
                .ForMember(destination => destination.JobOrderDescriptionOfWorkId, source => source.Ignore())
                .ForMember(destination => destination.JobOrder, source => source.Ignore());

            CreateMap<JobOrderDescriptionOfWorkUpdateDto, JobOrderDescriptionOfWork>()
                .ForMember(destination => destination.JobOrderDescriptionOfWorkId, source => source.Ignore())
                .ForMember(destination => destination.JobOrder, source => source.Ignore())
       
                .ForMember(destination => destination.DateCreated, source => source.Ignore())
                .ForMember(destination => destination.IsActive, source => source.Ignore());

            CreateMap<JobOrderDescriptionOfWork, JobOrderDescriptionOfWorkUpdateDto>();
            CreateMap<JobOrderDescriptionOfWorkReadDto, JobOrderDescriptionOfWorkUpdateDto>();
        }
    }
}
