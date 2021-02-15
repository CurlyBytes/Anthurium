﻿using Anthurium.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Anthurium.Web.Services
{
    public class DashboardService
    {
        public HttpClient _httpClient;

        public DashboardService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<int> RunningTotalOfClients()
        {
            var response = await _httpClient.GetAsync($"api/dashboard/totalclients");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<int>(responseContent);
            }

            return new int();
        }

        public async Task<int> DashboardJobOrderPerClient()
        {
            var response = await _httpClient.GetAsync($"api/dashboard/joborderwithinmonth");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<int>(responseContent);
            }

            return new int();
        }

        public async Task<JobOrderPerClientReadDto> JobOrderPerClient()
        {
            var response = await _httpClient.GetAsync($"api/dashboard/joborderperclient");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<JobOrderPerClientReadDto>(responseContent);
            }

            return new JobOrderPerClientReadDto();
        }
    }
}