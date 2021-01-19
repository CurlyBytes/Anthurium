using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories.SqlServer
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
            return _context.ClientInformations.FirstOrDefault(p => p.Id == Id);
        }

   

        public IEnumerable<ClientInformation> GetClientInformation()
        {
            return _context.ClientInformations.ToList();
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
