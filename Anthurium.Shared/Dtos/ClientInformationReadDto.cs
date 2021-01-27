using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Anthurium.Shared.Models;

namespace Anthurium.Shared.Dtos
{
    public class ClientInformationReadDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(450)]
        public string CompanyAddress { get; set; }

        

        
    }
}
