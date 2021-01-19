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

        IEnumerable<ClientInformation> GetClientInformation();
        ClientInformation ClientInformationById(int Id);

        void NewClientInformation(ClientInformation clientInformation);

        void UpdateClientInformation(ClientInformation clientInformation);

        void RemoveClientInformation(ClientInformation clientInformation);

        ClientInformation NewClientByDateWithin30Days();

        ClientInformation RunningTotalOfClients(int Id);
    }
}
