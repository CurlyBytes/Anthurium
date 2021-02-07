using Anthurium.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Anthurium.Web.Repositories
{
    public interface IClientInformation
    {
        bool SaveChanges();

        IEnumerable<ClientInformation> GetClientInformation();
        ClientInformation ClientInformationById(int Id);
        IEnumerable<JobOrder> JobOrderPerClientId(int Id);
        void NewClientInformation(ClientInformation clientInformation);

        void UpdateClientInformation(ClientInformation clientInformation);

        void RemoveClientInformation(ClientInformation clientInformation);

        int NewClientByDateWithin30Days();

        ClientInformation RunningTotalOfClients(int Id);
    }
}
