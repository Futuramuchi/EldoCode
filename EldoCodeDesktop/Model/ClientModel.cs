using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldoCodeDesktop.Model
{
    public class ClientModel
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public CountryModel Country { get; set; }
        public RegionModel Region { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
