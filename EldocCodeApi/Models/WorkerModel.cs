using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EldocCodeApi.Models
{
    public class WorkerModel
    {
        public WorkerModel(Worker worker = null)
        {
            if (worker != null)
            {

                Id = worker.Id;
                FirstName = worker.FirstName;
                MiddleName = worker.MiddleName;
                LastName = worker.LastName;
                Email = worker.Email;
                Phone = worker.Phone;
                Store = new StoreModel(worker.Store);
                Role = new RoleModel(worker.Role);
                Photo = worker.Photo;
            }
        }
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public RoleModel Role { get; set; }
        public StoreModel Store { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public byte[] Photo { get; set; }

    }
}