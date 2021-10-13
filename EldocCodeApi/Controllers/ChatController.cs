using EldocCodeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace EldocCodeApi.Controllers
{
    public class ChatController : ApiController
    {
        private EldoCodeEntities _ent;

        public ChatController()
        {
            _ent = new EldoCodeEntities();
        }

        public IHttpActionResult Get([FromUri] string secretKey, int chatId)
        {
            return Ok(_ent.Chat.Where(x => x.SecretKey == secretKey && x.Id == chatId).ToList().ConvertAll(x => new ChatModel(x)));
        }

        public IHttpActionResult Get()
        {
            return Ok(_ent.Chat.ToList().ConvertAll(x => new ChatModel(x)));
        }
    }
}