using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EldocCodeApi.Models
{
    public class ClientModel
    {
        public ClientModel(Client client = null)
        {
            if (client != null)
            {
                Id = client.Id;
                FirstName = client.FirstName;
                Email = client.Email;
                DateCreated = (DateTime)client.DateCreated;
            }
        }
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public DateTime DateCreated { get; set; }
    }
}