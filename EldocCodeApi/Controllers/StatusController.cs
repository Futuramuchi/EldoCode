using EldocCodeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace EldocCodeApi.Controllers
{
    public class StatusController : ApiController
    {
        private EldoCodeEntities _ent;

        public StatusController()
        {
            _ent = new EldoCodeEntities();
        }

        public IHttpActionResult Get()
        {
            return Ok(_ent.Status.ToList().ConvertAll(x => new StatusModel(x)));
        }
    }
}