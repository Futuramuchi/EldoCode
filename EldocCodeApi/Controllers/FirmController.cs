using EldocCodeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace EldocCodeApi.Controllers
{
    public class FirmController : ApiController
    {
        private EldoCodeEntities _ent;
        public FirmController()
        {
            _ent = new EldoCodeEntities();
        }

        public IHttpActionResult Get()
        {
            return Ok(_ent.Firm.ToList().ConvertAll(x => new FirmModel(x)));
        }
    }
}