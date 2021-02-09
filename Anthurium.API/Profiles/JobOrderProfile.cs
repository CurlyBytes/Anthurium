using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anthurium.API.Dtos;
using Anthurium.Shared.Models;
using AutoMapper;

namespace Anthurium.API.Profiles
{
    public class JobOrderProfile : Profile
    {
        public JobOrderProfile()
        {
            //source->target
    

            CreateMap<JobOrder, JobOrderReadDto>();
            CreateMap<JobOrderCreateDto, JobOrder>()
                .ForMember(destination => destination.JobOrderDescriptionOfWork, source => source.Ignore())
                .ForMember(destination => destination.JobOrderId, source => source.Ignore())
                .ForMember(destination => destination.ClientInformation, source => source.Ignore());

            CreateMap<JobOrderUpdateDto, JobOrder>()
                 .ForMember(destination => destination.JobOrderDescriptionOfWork, source => source.Ignore())
                .ForMember(destination => destination.JobOrderId, source => source.Ignore())
                .ForMember(destination => destination.ClientInformation, source => source.Ignore());
            CreateMap<JobOrder, JobOrderUpdateDto>();

            //web razor comp on edit clientinformation
            CreateMap<JobOrderReadDto, JobOrderUpdateDto>();

           


        }
    }
}
