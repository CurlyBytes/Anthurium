using Anthurium.API.Dtos;
using Anthurium.Shared.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Profiles
{
    public class JobQuotationDetailsProfile : Profile
    {
        public JobQuotationDetailsProfile()
        {
            //source->target
            CreateMap<JobQuotationDetails, JobQuotationDetailsReadDto>();
            CreateMap<JobQuotationDetailsCreateDto, JobQuotationDetails>()
                .ForMember(destination => destination.JobQuotationDetailsId, source => source.Ignore())
                .ForMember(destination => destination.JobQuotation, source => source.Ignore());

            CreateMap<JobQuotationDetailsUpdateDto, JobQuotationDetails>()
               
                .ForMember(destination => destination.JobQuotation, source => source.Ignore())

                .ForMember(destination => destination.DateCreated, source => source.Ignore())
                .ForMember(destination => destination.IsActive, source => source.Ignore());

            CreateMap<JobQuotationDetails, JobQuotationDetailsUpdateDto>();
            CreateMap<JobQuotationDetailsReadDto, JobQuotationDetailsUpdateDto>();

            CreateMap<ItemReadDto, JobQuotationUpdateDto>();
        }
    }
}
