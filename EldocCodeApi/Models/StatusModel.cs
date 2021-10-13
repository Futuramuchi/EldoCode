using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EldocCodeApi.Models
{
    public class StatusModel
    {
        public StatusModel(Status status = null)
        {
            if (status != null)
            {
                Id = status.Id;
                Name = status.Name;
            }
            
        }

        public int? Id { get; set; }
        public string Name { get; set; }
    }
}