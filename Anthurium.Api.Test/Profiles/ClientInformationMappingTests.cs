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
        private ClientInformation[] _clientInformation;
 
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

    

    }
}
