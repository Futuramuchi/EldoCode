using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EldocCodeApi.Models
{
    public class CountryModel
    {
        public CountryModel(Country country = null)
        {
            if (country != null)
            {
                Id = country.Id;
                Name = country.Name;

            }
        }
        public int? Id { get; set; }
        public string Name { get; set; }
    }
}