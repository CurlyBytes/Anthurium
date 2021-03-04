using Anthurium.API.Data;
using Anthurium.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Anthurium.Web.Repositories
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

        public IEnumerable<JobOrder> JobOrderPerClientId(int Id)
        {
            var result = _context.JobOrders.Where(j => j.ClientInformationId == Id);
            return result;
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

        public int RunningTotalOfClients()
        {
            return _context.ClientInformations
               .Where(ci => ci.IsActive == true)
               .Count();
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
