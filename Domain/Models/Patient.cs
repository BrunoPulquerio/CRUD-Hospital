using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Patient:Entity
    {
        
        public string Name { get; set; }

        public string CPF { get; set; }

        public DateTime Birthday { get; set; }

        public string Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

    }
}
