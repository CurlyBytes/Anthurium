using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IClientInformation
    {
        bool SaveChanges();

        IEnumerable<ClientInformation> GetJobOrders();
        ClientInformation GetJobOrderById(int Id);

        void NewClientInformation(ClientInformation clientInformation);

        void UpdateClientInformation(ClientInformation clientInformation);

        void RemoveClientInformation(ClientInformation clientInformation);

        ClientInformation NewClientByDateWithin30Days();

        ClientInformation RunningTotalOfClients(int Id);
    }
}
