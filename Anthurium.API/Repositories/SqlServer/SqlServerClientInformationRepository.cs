using Anthurium.API.Data;
using Anthurium.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Anthurium.Web.Repositories.SqlServer
{
    public class SqlServerClientInformationRepository : IClientInformation
    {
        private readonly AnthuriumContext _context;


        public SqlServerClientInformationRepository(AnthuriumContext context)
        {
            _context = context;
        }

        public ClientInformation ClientInformationById(int Id)
        {
            return _context.ClientInformations.FirstOrDefault(p => p.ClientInformationId == Id);
        }
         
   

        public IEnumerable<ClientInformation> GetClientInformation()
        {
            return _context.ClientInformations.ToList();
        }

        public IQueryable<ClientInformation> JobOrderPerClientId(int Id)
        {
            return _context.ClientInformations
              .Where(ci => ci.ClientInformationId == Id)
              .Include(j => j.JobOrder);
        }

        public ClientInformation NewClientByDateWithin30Days()
        {
            throw new NotImplementedException();
        }

        public void NewClientInformation(ClientInformation clientInformation)
        {
            if (clientInformation == null)
            {
                throw new ArgumentNullException(nameof(clientInformation));
            }

            _context.ClientInformations.Add(clientInformation);
        }

        public void RemoveClientInformation(ClientInformation clientInformation)
        {
            if (clientInformation == null)
            {
                throw new ArgumentNullException(nameof(clientInformation));
            }

            _context.ClientInformations.Remove(clientInformation);
        }

        public ClientInformation RunningTotalOfClients(int Id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()) >= 0;
        }

        public void UpdateClientInformation(ClientInformation clientInformation)
        {
            //nothing
        }
    }
}
