using Anthurium.API.Dtos;
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

         
            //builder.EntitySet<ClientInformationReadDto>("ClientInformation");



            builder.EntitySet<ClientInformationReadDto>("ClientInformation").EntityType.HasKey(x => x.ClientInformationId);

            var fnGetAllClientINformation = builder.Function("GetAll");
            fnGetAllClientINformation.ReturnsCollectionFromEntitySet<ClientInformationReadDto>("ClientInformation");

            var fnGeByIdClientINformation = builder.Function("GetById");
            fnGeByIdClientINformation.Parameter<int>("id");
            fnGeByIdClientINformation.ReturnsCollectionFromEntitySet<ClientInformationReadDto>("ClientInformation");

            var fnCreateClientInformation = builder.Function("CreateClientInformation");
            fnCreateClientInformation.ReturnsCollectionFromEntitySet<ClientInformationReadDto>("ClientInformation");


            var fnJobOrderPerClientId = builder.EntityType<ClientInformationReadDto>().Collection
                .Function("JobOrders")
                .ReturnsCollectionFromEntitySet<ClientInformationReadDto>("ClientInformation");
            fnJobOrderPerClientId.Parameter<int>("clientInformationId").Required();
            fnJobOrderPerClientId.Parameter<int>("jobOrderClientInformationId").Optional();
            //-------------------------------


            builder.EntitySet<JobOrderDescriptionOfWorkReadDto>("JobOrderDescriptionOfWork").EntityType.HasKey(x => x.JobOrderDescriptionOfWorkId);

            var fnGetAllJobOrderDescriptionOfWork = builder.Function("GetAll");
            fnGetAllJobOrderDescriptionOfWork.ReturnsCollectionFromEntitySet<JobOrderDescriptionOfWorkReadDto>("JobOrderDescriptionOfWork");

            var fnGeByIdJobOrderDescriptionOfWork = builder.Function("GetById");
            fnGeByIdJobOrderDescriptionOfWork.Parameter<int>("id");
            fnGeByIdJobOrderDescriptionOfWork.ReturnsCollectionFromEntitySet<JobOrderDescriptionOfWorkReadDto>("JobOrderDescriptionOfWork");

            var fnCreateJobOrderDescriptionOfWork = builder.Function("CreateJobOrderDescriptionOfWork");
            fnCreateJobOrderDescriptionOfWork.ReturnsCollectionFromEntitySet<JobOrderDescriptionOfWorkReadDto>("JobOrderDescriptionOfWork");
            //-----------------------------

            builder.EntitySet<JobOrderReadDto>("JobOrder").EntityType.HasKey(x => x.JobOrderId);

            var fnGetAllJobOrder = builder.Function("GetAll");
            fnGetAllJobOrder.ReturnsCollectionFromEntitySet<JobOrderReadDto>("JobOrder");

            var fnGeByIdJobOrder = builder.Function("GetById");
            fnGeByIdJobOrder.Parameter<int>("id");
            fnGeByIdJobOrder.ReturnsCollectionFromEntitySet<JobOrderReadDto>("JobOrder");

            var fnCreateJobOrder = builder.Function("CreateJobOrder");
            fnCreateJobOrder.ReturnsCollectionFromEntitySet<JobOrderReadDto>("JobOrder");


            var fnJobOrderPerClient = builder.Function("JobOrderPerClient");
            fnJobOrderPerClient.ReturnsCollectionFromEntitySet<JobOrderReadDto>("JobOrder");

            //------------------------------

            builder.EntitySet<JobQuotationDetailsReadDto>("JobQuotationDetails").EntityType.HasKey(x => x.JobQuotationDetailsId);
            builder.EntitySet<JobQuotationDetailsReadDto>("JobQuotationDetailsPerJobQuotation").EntityType.HasKey(x => x.JobQuotationDetailsId);

            var fnGetJobQuotationDetailsByJobQuotation = builder.EntityType<JobQuotationDetailsReadDto>().Collection
              .Function("JobQuotation")
              .ReturnsCollectionFromEntitySet<JobQuotationDetailsReadDto>("JobQuotationDetailsPerJobQuotation");
            fnGetJobQuotationDetailsByJobQuotation.Parameter<int>("JobQuotationId").Required();
            //-----------------------------------

            builder.EntitySet<JobQuotationReadDto>("JobQuotation").EntityType.HasKey(x => x.JobQuotationId);
       
            var fnJobOrderQuotationByClient = builder.EntityType<JobQuotationReadDto>().Collection
               .Function("ClientInformation")
               .ReturnsCollectionFromEntitySet<JobQuotationReadDto>("JobQuotation");
            fnJobOrderQuotationByClient.Parameter<int>("ClientInformationId").Required();

            //==============
            builder.EntitySet<WarehouseReadDto>("Warehouse").EntityType.HasKey(x => x.WarehouseId);

            var fnGetAllWarehouse = builder.Function("GetAll");
            fnGetAllWarehouse.ReturnsCollectionFromEntitySet<WarehouseReadDto>("Warehouse");

            var fnGeByIdWarehouse = builder.Function("GetById");
            fnGeByIdWarehouse.Parameter<int>("id");
            fnGeByIdWarehouse.ReturnsCollectionFromEntitySet<WarehouseReadDto>("Warehouse");

            var fnCreateWarehouse = builder.Function("CreateWarehouse");
            fnCreateWarehouse.ReturnsCollectionFromEntitySet<WarehouseReadDto>("Warehouse");


            return builder.GetEdmModel();
        }
    }
}
