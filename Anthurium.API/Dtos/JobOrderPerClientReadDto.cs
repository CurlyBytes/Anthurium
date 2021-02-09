using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Dtos
{
    public class JobOrderPerClientReadDto
    {
        public string CompanyName { get; set; }

        public int NumberOfJobOrder { get; set; }


        public DateTime DateUpdated { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsActive { get; set; }
    }
}
