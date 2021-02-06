using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.Web.Models
{
    public class ListPrefs
    {
        public string OrderBy { get; set; } = "ClientInformationId";
        public int NumResults { get; set; } = 10; //results per page
    }
}
