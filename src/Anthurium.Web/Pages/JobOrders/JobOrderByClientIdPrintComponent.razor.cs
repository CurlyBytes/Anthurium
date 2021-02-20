using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
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


        [Parameter]
        public int Id { get; set; }

       

        protected async void OnPrintClickPdf()
        {
            // ins
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
            var page = await browser.NewPageAsync();
            await page.GoToAsync("http://localhost:5002");
            await page.PdfAsync("joborder.pdf");
        }

        protected async void OnPrintClickPdffff()
        {
           
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);

            byte[] pdfBytes;

            PuppeteerSharp.Browser browser = null;
            Page page = null;

            try
            {
                browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true });

                page = await browser.NewPageAsync();

                await page.SetViewportAsync(new ViewPortOptions()
                {
                    Height = 600,
                    Width = 800
                });

                await page.GoToAsync("http://localhost:5002/joborder/print");



                pdfBytes = await page.PdfDataAsync(new PdfOptions
                {
                    PrintBackground = true,
                    Width = 600.ToString() + "px",
                    Height = 790.ToString() + "px"
                });

                await _iJSRuntime.InvokeVoidAsync("BlazorDownloadFile", $"{DateTime.UtcNow}-joborder.pdf", "application/pdf", pdfBytes);
                // var bytes = await HttpClient.GetByteArrayAsync("api/pictures/1");
                // await BlazorDownloadFileService.DownloadFile("joborder.pdf", pdfBytes, BufferSize, "application/octet-stream");
            }
            finally
            {
                if (!page?.IsClosed ?? false)
                {
                    await page?.CloseAsync();
                }

                page?.Dispose();

                if (!browser?.IsClosed ?? false)
                {
                    await browser?.CloseAsync();
                }

                browser?.Dispose();
            }
        }


     
    }


}
