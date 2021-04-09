using Anthurium.API.Dtos;
using Anthurium.Web.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Anthurium.Web.Services {
  public class JobQuotationDetailsDetails : IJobQuotationDetailsDetails {
    private IHttpService _httpService;

    public JobQuotationDetailsDetails(IHttpService httpService) {
      _httpService = httpService;
    }

    public async Task<JobQuotationDetailsApiResponse>
    GetJobQuotationDetailssAsync(string orderBy, int skip, int top) {
      return await _httpService.Get<JobQuotationDetailsApiResponse>(
          $"api/jobquotationdetails?$count=true&$orderby={orderBy}&$skip={skip}&$top={top}");
    }

    public async Task<JobQuotationDetailsApiResponse>
    JobQuotationDetailsByJobOrder(string orderBy, int skip, int top,
                                  int jobQuotationId) {
      return await _httpService.Get<JobQuotationDetailsApiResponse>(
          $"api/jobquotationdetails?$count=true&$filter=JobQuotationId eq {jobQuotationId}&$orderby={orderBy}&$skip={skip}&$top={top}");
    }

    public async Task<JobQuotationDetailsApiResponse>
    JobQuotationDetailsByJobOrder(string orderBy, int jobQuotationId) {
      return await _httpService.Get<JobQuotationDetailsApiResponse>(
          $"api/jobquotationdetails?$count=true&$filter=JobQuotationId eq {jobQuotationId}&$orderby={orderBy}");
    }

    public async Task<JobQuotationDetailsReadDto>
    GetJobQuotationDetailsByIdAsync(int id) {
      return await _httpService.Get<JobQuotationDetailsReadDto>(
          $"api/jobquotationdetails/{id}");
    }

    public async Task DeleteJobQuotationDetailsByIdAsync(int id) {
      // consider impact vs returning just status code
      await _httpService.Delete($"api/jobquotationdetails/{id}");
    }

    public async Task<HttpResponseMessage> CreateJobQuotationDetailsAsync(
        JobQuotationDetailsCreateDto clientinformation) {

      return await _httpService.Post<HttpResponseMessage>(
          $"api/jobquotationdetails", clientinformation);
    }

    public async Task EditJobQuotationDetailsAsync(
        int id, JobQuotationDetailsUpdateDto clientinformation) {

      await _httpService.Put($"api/jobquotationdetails/{id}",
                             clientinformation);
    }
  }
}
