using Anthurium.API.Dtos;
using Anthurium.Shared.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Anthurium.API.Profiles
{
    public class ClientInformationProfile : Profile
    {
        public ClientInformationProfile()
        {
            //source->target
            //api get,post,update(delete)
            CreateMap<ClientInformation, ClientInformationReadDto>();
            CreateMap<ClientInformationCreateDto, ClientInformation>()
            .ForMember(destination => destination.ClientInformationId, source => source.Ignore())
            .ForMember(destination => destination.JobOrder, source => source.Ignore())
            .ForMember(destination => destination.JobQuotation, source => source.Ignore());

            CreateMap<ClientInformationUpdateDto, ClientInformation>()
                .ForMember(destination => destination.ClientInformationId, source => source.Ignore())
                .ForMember(destination => destination.JobOrder, source => source.Ignore())
                .ForMember(destination => destination.JobQuotation, source => source.Ignore());

            CreateMap<ClientInformation, ClientInformationUpdateDto>();

            //web razor comp on edit clientinformation
            CreateMap<ClientInformationReadDto, ClientInformationUpdateDto>();

            //web razor comp on add joborder
            CreateMap<ClientInformationReadDto, JobOrderChangeCreate>()
             .ForMember(dest => dest.ClientInformationId, opt => opt.MapFrom(src => src.ClientInformationId)); 

            CreateMap<JobOrderChangeCreate, JobOrderCreateDto>()
                .ForMember(destination => destination.ContactPerson, source => source.Ignore())
                .ForMember(destination => destination.ContactNumber, source => source.Ignore())
                .ForMember(destination => destination.TimeStarted, source => source.Ignore())
                .ForMember(destination => destination.TimeEnded, source => source.Ignore())
                .ForMember(destination => destination.TotalHours, source => source.Ignore());

            CreateMap<JobOrderChangeCreate, JobOrderUpdateDto>()
                .ForMember(destination => destination.ContactPerson, source => source.Ignore())
                .ForMember(destination => destination.ContactNumber, source => source.Ignore())
                .ForMember(destination => destination.TimeStarted, source => source.Ignore())
                .ForMember(destination => destination.TimeEnded, source => source.Ignore())
                .ForMember(destination => destination.TotalHours, source => source.Ignore());

            //CreateMap<Object, List<ClientInformationReadDto>>();
        }

       
    }
}
