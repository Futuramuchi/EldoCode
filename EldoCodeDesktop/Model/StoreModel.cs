using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldoCodeDesktop.Model
{
    public class StoreModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public CountryModel Country { get; set; }
        public RegionModel Region { get; set; }
    }
}
