using Anthurium.API.Dtos;
using Anthurium.Web.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Anthurium.Web.Services {
  public class JobQuotationService : IJobQuotationService {
    public IHttpService _httpService;

    public JobQuotationService(IHttpService httpService) {
      _httpService = httpService;
    }

    public async Task<JobQuotationApiResponse>
    GetJobQuotationsAsync(string orderBy, int skip, int top) {
      return await _httpService.Get<JobQuotationApiResponse>(
          $"api/jobquotation?$count=true&$orderby={orderBy}&$skip={skip}&$top={top}");
    }

    public async Task<JobQuotationApiResponse>
    JobOrderQuotationByClient(string orderBy, int skip, int top,
                              int clientInformationId) {
      return await _httpService.Get<JobQuotationApiResponse>(
          $"api/jobquotation?$count=true&$filter=ClientInformationId eq {clientInformationId}&$orderby={orderBy}&$skip={skip}&$top={top}");
    }

    public async Task<JobQuotationReadDto> GetJobQuotationByIdAsync(int id) {
      return await _httpService.Get<JobQuotationReadDto>(
          $"api/jobquotation/{id}");
    }

    public async Task DeleteJobQuotationByIdAsync(int id) {
      // consider impact vs returning just status code
      await _httpService.Delete($"api/jobquotation/{id}");
    }

    public async Task<HttpResponseMessage>
    CreateJobQuotationAsync(JobQuotationCreateDto clientinformation) {

      return await _httpService.Post<HttpResponseMessage>($"api/jobquotation",
                                                          clientinformation);
    }

    public async Task
    EditJobQuotationAsync(int id, JobQuotationUpdateDto clientinformation) {

      await _httpService.Put($"api/jobquotation/{id}", clientinformation);
    }
  }
}
