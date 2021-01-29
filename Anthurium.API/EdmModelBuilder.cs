﻿using Anthurium.API.Dtos;
using Anthurium.Shared.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API
{
    public static class EdmModelBuilder
    {
        public static IEdmModel Build()
        {
            // create OData builder instance
            var builder = new ODataConventionModelBuilder();

            builder.EntitySet<Contact>("Contacts");
            //builder.EntitySet<ClientInformationReadDto>("ClientInformation");



            builder.EntitySet<ClientInformationReadDto>("ClientInformation").EntityType.HasKey(x => x.Id);

            var fnGetAllClientINformation = builder.Function("GetAll");
            fnGetAllClientINformation.ReturnsCollectionFromEntitySet<ClientInformationReadDto>("ClientInformation");

            var fnGeByIdClientINformation = builder.Function("GetById");
            fnGeByIdClientINformation.Parameter<int>("id");
            fnGeByIdClientINformation.ReturnsCollectionFromEntitySet<ClientInformationReadDto>("ClientInformation");

            var fnCreateClientInformation = builder.Function("CreateClientInformation");
            fnCreateClientInformation.ReturnsCollectionFromEntitySet<ClientInformationReadDto>("ClientInformation");


            builder.EntitySet<JobOrderDescriptionOfWorkReadDto>("JobOrderDescriptionOfWork").EntityType.HasKey(x => x.Id);

            var fnGetAllJobOrderDescriptionOfWork = builder.Function("GetAll");
            fnGetAllJobOrderDescriptionOfWork.ReturnsCollectionFromEntitySet<JobOrderDescriptionOfWorkReadDto>("JobOrderDescriptionOfWork");

            var fnGeByIdJobOrderDescriptionOfWork = builder.Function("GetById");
            fnGeByIdJobOrderDescriptionOfWork.Parameter<int>("id");
            fnGeByIdJobOrderDescriptionOfWork.ReturnsCollectionFromEntitySet<JobOrderDescriptionOfWorkReadDto>("JobOrderDescriptionOfWork");

            var fnCreateJobOrderDescriptionOfWork = builder.Function("CreateJobOrderDescriptionOfWork");
            fnCreateJobOrderDescriptionOfWork.ReturnsCollectionFromEntitySet<JobOrderDescriptionOfWorkReadDto>("JobOrderDescriptionOfWork");


            builder.EntitySet<JobOrderReadDto>("JobOrder").EntityType.HasKey(x => x.Id);

            var fnGetAllJobOrder = builder.Function("GetAll");
            fnGetAllJobOrder.ReturnsCollectionFromEntitySet<JobOrderReadDto>("JobOrder");

            var fnGeByIdJobOrder = builder.Function("GetById");
            fnGeByIdJobOrder.Parameter<int>("id");
            fnGeByIdJobOrder.ReturnsCollectionFromEntitySet<JobOrderReadDto>("JobOrder");

            var fnCreateJobOrder = builder.Function("CreateJobOrder");
            fnCreateJobOrder.ReturnsCollectionFromEntitySet<JobOrderReadDto>("JobOrder");

            return builder.GetEdmModel();
        }
    }
}