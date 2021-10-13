using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EldocCodeApi.Models
{
    public class RegionModel
    {
        public RegionModel(Region region = null)
        {
            if (region != null)
            {
                Id = region.Id;
                Name = region.Name;

            }
        }
        public int? Id { get; set; }
        public string Name { get; set; }
    }
}