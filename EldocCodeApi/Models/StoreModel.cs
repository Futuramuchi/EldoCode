using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EldocCodeApi.Models
{
    public class StoreModel
    {
        public StoreModel(Store store)
        {
            if (store != null)
            {
                Id = store.Id;
                Address = store.Address;
                Country = new CountryModel(store.Country);
                Region = new RegionModel(store.Region);

            }
        }
        public int Id { get; set; }
        public string Address { get; set; }
        public CountryModel Country { get; set; }
        public RegionModel Region { get; set; }
    }
}