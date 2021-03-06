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

            //==============
            builder.EntitySet<VendorReadDto>("Vendor").EntityType.HasKey(x => x.VendorId);

            var fnGetAllVendor = builder.Function("GetAll");
            fnGetAllVendor.ReturnsCollectionFromEntitySet<VendorReadDto>("Vendor");

            var fnGeByIdVendor = builder.Function("GetById");
            fnGeByIdVendor.Parameter<int>("id");
            fnGeByIdVendor.ReturnsCollectionFromEntitySet<VendorReadDto>("Vendor");

            var fnCreateVendor = builder.Function("CreateVendor");
            fnCreateVendor.ReturnsCollectionFromEntitySet<VendorReadDto>("Vendor");

            //==============
            builder.EntitySet<ItemReadDto>("Item").EntityType.HasKey(x => x.ItemId);

            var fnGetAllItem = builder.Function("GetAll");
            fnGetAllItem.ReturnsCollectionFromEntitySet<ItemReadDto>("Item");

            var fnGeByIdItem = builder.Function("GetById");
            fnGeByIdItem.Parameter<int>("id");
            fnGeByIdItem.ReturnsCollectionFromEntitySet<ItemReadDto>("Item");

            var fnCreateItem = builder.Function("CreateItem");
            fnCreateItem.ReturnsCollectionFromEntitySet<ItemReadDto>("Item");

            //==============
            builder.EntitySet<AssetReadDto>("Asset").EntityType.HasKey(x => x.AssetId);

            var fnGetAllAsset = builder.Function("GetAll");
            fnGetAllAsset.ReturnsCollectionFromEntitySet<AssetReadDto>("Asset");

            var fnGeByIdAsset = builder.Function("GetById");
            fnGeByIdAsset.Parameter<int>("id");
            fnGeByIdAsset.ReturnsCollectionFromEntitySet<AssetReadDto>("Asset");

            var fnCreateAsset = builder.Function("CreateAsset");
            fnCreateAsset.ReturnsCollectionFromEntitySet<AssetReadDto>("Asset");

            //==============
            builder.EntitySet<DeliveryReceiptReadDto>("DeliveryReceipt").EntityType.HasKey(x => x.DeliveryReceiptId);

            var fnGetAllDeliveryReceipt = builder.Function("GetAll");
            fnGetAllDeliveryReceipt.ReturnsCollectionFromEntitySet<DeliveryReceiptReadDto>("DeliveryReceipt");

            var fnGeByIdDeliveryReceipt = builder.Function("GetById");
            fnGeByIdDeliveryReceipt.Parameter<int>("id");
            fnGeByIdDeliveryReceipt.ReturnsCollectionFromEntitySet<DeliveryReceiptReadDto>("DeliveryReceipt");

            var fnCreateDeliveryReceipt = builder.Function("CreateDeliveryReceipt");
            fnCreateDeliveryReceipt.ReturnsCollectionFromEntitySet<DeliveryReceiptReadDto>("DeliveryReceipt");


            //==============
            builder.EntitySet<DeliveryReceiptDetailsReadDto>("DeliveryReceiptDetails").EntityType.HasKey(x => x.DeliveryReceiptDetailsId);

            var fnGetAllDeliveryReceiptDetails = builder.Function("GetAll");
            fnGetAllDeliveryReceiptDetails.ReturnsCollectionFromEntitySet<DeliveryReceiptDetailsReadDto>("DeliveryReceiptDetails");

            var fnGeByIdDeliveryReceiptDetails = builder.Function("GetById");
            fnGeByIdDeliveryReceiptDetails.Parameter<int>("id");
            fnGeByIdDeliveryReceiptDetails.ReturnsCollectionFromEntitySet<DeliveryReceiptDetailsReadDto>("DeliveryReceiptDetails");

            var fnCreateDeliveryReceiptDetails = builder.Function("CreateDeliveryReceiptDetails");
            fnCreateDeliveryReceiptDetails.ReturnsCollectionFromEntitySet<DeliveryReceiptDetailsReadDto>("DeliveryReceiptDetails");
            return builder.GetEdmModel();
        }
    }
}
