using EldocCodeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace EldocCodeApi.Controllers
{
    public class ClientController : ApiController
    {
        private EldoCodeEntities _ent;

        public ClientController()
        {
            _ent = new EldoCodeEntities();
        }

        public IHttpActionResult Get()
        {
            return Ok(_ent.Client.ToList().ConvertAll(x => new ClientModel(x)));
        }

        public async Task<HttpResponseMessage> Post([FromBody] ClientModel client)
        {
            Client clientData = new Client()
            {
                FirstName = client.FirstName,
                Email = client.Email,
                DateCreated = DateTime.Now
            };

            _ent.Client.Add(clientData);
            await _ent.SaveChangesAsync();

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, clientData.Id);
        }
    }
}