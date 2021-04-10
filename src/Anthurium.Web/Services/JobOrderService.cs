using Anthurium.API.Dtos;
using Anthurium.Web.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Anthurium.Web.Services {
  public class JobOrderService : IJobOrderService {
    public IHttpService _httpService;

    public JobOrderService(IHttpService httpService) {
      _httpService = httpService;
    }

    public async Task<JobOrderApiResponse>
    GetJobOrdersAsync(string orderBy, int skip, int top) {
      return await _httpService.Get<JobOrderApiResponse>(
          $"api/joborder?$count=true&$orderby={orderBy}&$skip={skip}&$top={top}");
    }

    public async Task<JobOrderApiResponse>
    GetJobOrdersByClientInfoAsync(string orderBy, int skip, int top,
                                  int clientInformationId) {
      return await _httpService.Get<JobOrderApiResponse>(
          $"api/joborder?$count=true&$filter=ClientInformationId eq {clientInformationId}&$orderby={orderBy}&$skip={skip}&$top={top}");
    }

    public async Task<JobOrderReadDto> GetJobOrderByIdAsync(int id) {
      return await _httpService.Get<JobOrderReadDto>($"api/joborder/{id}");
    }

    public async Task DeleteJobOrderByIdAsync(int id) {
      // consider impact vs returning just status code
      await _httpService.Delete($"api/joborder/{id}");
    }

    public async Task<HttpResponseMessage>
    CreateJobOrderAsync(JobOrderCreateDto joborderdescriptionofwork) {

      return await _httpService.Post<HttpResponseMessage>(
          $"api/joborder", joborderdescriptionofwork);
    }

    public async Task
    EditJobOrderAsync(long id, JobOrderUpdateDto joborderdescriptionofwork) {

      await _httpService.Put($"api/joborder/{id}", joborderdescriptionofwork);
    }
  }

}
