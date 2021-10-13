using EldocCodeApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace EldocCodeApi.Controllers
{
    public class WorkerController : ApiController
    {
        private EldoCodeEntities _ent;

        public WorkerController()
        {
            _ent = new EldoCodeEntities();
        }

        public async Task<HttpResponseMessage> Get([FromUri] string login, string password)
        {
            var worker = await _ent.Worker.FirstOrDefaultAsync(x => x.Login == login && x.Password == password);
            if (worker != null)
            {
                var workerData = new WorkerModel()
                {
                    Id = worker.Id,
                    FirstName = worker.FirstName,
                    MiddleName = worker.MiddleName,
                    LastName = worker.LastName,
                    Email = worker.Email,
                    Phone = worker.Phone,
                    Login = worker.Login,
                    Password = worker.Password,
                    Store = new StoreModel(worker.Store),
                    Role = new RoleModel(worker.Role),
                    Photo = worker.Photo
                };

                return Request.CreateResponse(System.Net.HttpStatusCode.OK, workerData);
            }
            return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "The user doesn't exist");

        }

        public IHttpActionResult Get()
        {
            return Ok(_ent.Worker.ToList().ConvertAll(x => new WorkerModel(x)));
        }

        public async Task<HttpResponseMessage> Post([FromBody] WorkerModel worker)
        {
            var isWorkerExist = _ent.Worker.ToList().TrueForAll(x => x.Login != worker.Login);

            if (!isWorkerExist)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "The user has already exist");
            }
            else
            {
                Worker workerData = new Worker()
                {
                    FirstName = worker.FirstName,
                    MiddleName = worker.MiddleName,
                    LastName = worker.LastName,
                    Email = worker.Email,
                    Phone = worker.Phone,
                    StoreId = worker.Store.Id,
                    RoleId = worker.Role.Id,
                    Login = worker.Login,
                    Password = worker.Password,
                    Photo = worker.Photo
                };


                _ent.Worker.Add(workerData);
                await _ent.SaveChangesAsync();

                return Request.CreateResponse(System.Net.HttpStatusCode.OK, "The new worker was successfully added!");                
            }
           
        }
    }
}