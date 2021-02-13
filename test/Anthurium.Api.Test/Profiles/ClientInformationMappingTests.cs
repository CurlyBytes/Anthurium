using Anthurium.API.Dtos;
using Anthurium.API.Profiles;
using Anthurium.Shared.Models;
using AutoMapper;
using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Anthurium.Api.Test.Profiles
{
    public class ClientInformationMappingTests
    {

        private IMapper _mapper;
        private MapperConfiguration _mapperConfiguration;
 
        public ClientInformationMappingTests()
        {
            //var mappings = new MapperConfigurationExpression();
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new ClientInformationProfile());
                    mc.AddProfile(new JobOrderProfile());
                    mc.AddProfile(new JobOrderDescriptionOfWorkProfile());
                    mc.AddProfile(new JobQuotationProfile());
                    mc.AddProfile(new JobQuotationDetailsProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
                _mapperConfiguration = mappingConfig;
            }


        }

        [Fact]
        public void AutoMapper_Configuration_IsValid()
        {
            _mapperConfiguration.AssertConfigurationIsValid();
        }



        [Fact]
        public void Should_AutoMapWorking_ClientInformationToClientInformationReadDto()
        {
            var entity = new ClientInformation();
            var dto = _mapper.Map<ClientInformationReadDto>(entity);

            Assert.NotNull(dto);
            Assert.IsType<ClientInformationReadDto>(dto);
        }

        [Fact]
        public void Should_AutoMapWorking_ClientInformationCreateDtoToClientInformation()
        {
            var dto = new ClientInformationCreateDto();
            var entity = _mapper.Map<ClientInformation>(dto);

            Assert.NotNull(entity);
            Assert.IsType<ClientInformation>(entity);
        }

        [Fact]
        public void Should_AutoMapWorking_ClientInformationUpdateDtoToClientInformationo()
        {
            var dto = new ClientInformationUpdateDto();
            var entity = _mapper.Map<ClientInformation>(dto);

            Assert.NotNull(entity);
            Assert.IsType<ClientInformation>(entity);
        }

        [Fact]
        public void Should_AutoMapWorking_ClientInformationToClientInformationUpdateDto()
        {
            var entity = new ClientInformation();
            var dto = _mapper.Map<ClientInformationUpdateDto>(entity);

            Assert.NotNull(dto);
            Assert.IsType<ClientInformationUpdateDto>(dto);
        }


        [Fact]
        public void Should_AutoMapWorking_ClientInformationReadDtoToClientInformationUpdateDto()
        {
            var sourceDto = new ClientInformationReadDto();
            var targetDto = _mapper.Map<ClientInformationUpdateDto>(sourceDto);

            Assert.NotNull(targetDto);
            Assert.IsType<ClientInformationUpdateDto>(targetDto);
        }


        [Fact]
        public void Should_AutoMapWorking_ClientInformationReadDtoToJobOrderChangeCreate()
        {
            var sourceDto = new ClientInformationReadDto();
            var targetDto = _mapper.Map<JobOrderChangeCreate>(sourceDto);

            Assert.NotNull(targetDto);
            Assert.IsType<JobOrderChangeCreate>(targetDto);
        }

        [Fact]
        public void Should_AutoMapWorking_JobOrderChangeCreateToJobOrderUpdateDto()
        {
            var sourceDto = new JobOrderChangeCreate();
            var targetDto = _mapper.Map<JobOrderUpdateDto>(sourceDto);

            Assert.NotNull(targetDto);
            Assert.IsType<JobOrderUpdateDto>(targetDto);
        }

        

    }
}
