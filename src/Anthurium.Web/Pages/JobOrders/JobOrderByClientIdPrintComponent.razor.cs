using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Anthurium.API.Dtos;
using BlazorDownloadFile;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PuppeteerSharp;


namespace Anthurium.Web.Pages.JobOrders
{
    public partial class JobOrderByClientIdPrintComponent : LayoutComponentBase
    {
        [Inject]
        protected IJSRuntime _iJSRuntime { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected Services.JobOrderService jobOrderService { get; set; }

        [Parameter]
        public int Id { get; set; }

       
       

        protected JobOrderReadDto jobOrderReadDto;

        protected override async Task OnInitializedAsync()
        {
            jobOrderReadDto = await jobOrderService.GetJobOrderByIdAsync(Id);
        }

    }


}
