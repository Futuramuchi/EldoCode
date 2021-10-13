using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EldocCodeApi.Models
{
    public class FirmModel
    {
        public FirmModel(Firm firm = null)
        {
            if (firm != null)
            {
                Id = firm.Id;
                Name = firm.Name;

            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}