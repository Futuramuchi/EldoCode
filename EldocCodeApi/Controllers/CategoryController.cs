using EldocCodeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace EldocCodeApi.Controllers
{
    public class CategoryController : ApiController
    {
        private EldoCodeEntities _ent;
        public CategoryController()
        {
            _ent = new EldoCodeEntities();
        }

        public IHttpActionResult Get()
        {
            return Ok(_ent.Category.ToList().ConvertAll(x => new CategoryModel(x)));
        }
    }
}