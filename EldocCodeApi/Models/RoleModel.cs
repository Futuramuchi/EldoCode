using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EldocCodeApi.Models
{
    public class RoleModel
    {
        public RoleModel(Role role = null)
        {
            if (role != null)
            {
                Id = role.Id;
                Name = role.Name;

            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}