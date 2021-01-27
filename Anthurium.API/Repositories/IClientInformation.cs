using Anthurium.Shared.Models;
using System;
using System.Collections.Generic;


namespace Anthurium.Web.Repositories
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
