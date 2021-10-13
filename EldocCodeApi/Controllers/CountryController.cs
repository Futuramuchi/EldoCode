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
    public class CountryController : ApiController
    {
        private EldoCodeEntities _ent;

        public CountryController()
        {
            _ent = new EldoCodeEntities();
        }

        public IHttpActionResult Get()
        {
            return Ok(_ent.Country.ToList().ConvertAll(x => new CountryModel(x)));
        }
    }
}