using Anthurium.API.Dtos;
using System.Threading.Tasks;

namespace Anthurium.Web.Services
{
    public interface IDashboardService
    {
        Task<int> DashboardJobOrderPerClient();
        Task<JobOrderPerClientReadDto> JobOrderPerClient();
        Task<int> RunningTotalOfClients();
    }
}