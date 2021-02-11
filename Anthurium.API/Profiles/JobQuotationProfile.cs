using Anthurium.API.Dtos;
using Anthurium.Shared.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Profiles
{
    public class JobQuotationProfile : Profile
    {
        //source->target

        public JobQuotationProfile()
        {
            CreateMap<JobQuotation, JobQuotationReadDto>()
                .ForMember(dest => dest.JobQuotationDetails, opt => opt.MapFrom(src => src.JobQuotationDetails));
            CreateMap<JobQuotationCreateDto, JobQuotation>()
                 .ForMember(destination => destination.JobQuotationId, source => source.Ignore());
            CreateMap<JobQuotationUpdateDto, JobQuotation>()
                 .ForMember(destination => destination.DateCreated, source => source.Ignore())
                .ForMember(destination => destination.IsActive, source => source.Ignore());
            CreateMap<JobQuotation, JobQuotationUpdateDto>();

            //web razor comp on edit clientinformation
            CreateMap<JobQuotationReadDto, JobQuotationUpdateDto>();
        }


    }
}
