using Anthurium.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks; 

namespace Anthurium.Web.Services
{
    public class DashboardService : IDashboardService
    {
        private IHttpService _httpService;

        public DashboardService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<int> RunningTotalOfClients()
        {
            return await _httpService.Get<int>($"api/dashboard/totalclients");

        }

        public async Task<int> DashboardJobOrderPerClient()
        {
            return await _httpService.Get<int>($"api/dashboard/joborderwithinmonth");


        }

        public async Task<JobOrderPerClientReadDto> JobOrderPerClient()
        {
            return await _httpService.Get<JobOrderPerClientReadDto>($"api/dashboard/joborderperclient");


        }
    }
}
