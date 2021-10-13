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
    public class MessageController : ApiController
    {
        private EldoCodeEntities _ent;

        public MessageController()
        {
            _ent = new EldoCodeEntities();
        }

        public async Task<HttpResponseMessage> Post([FromBody] MessageModel message)
        {
            Message messageData = new Message()
            {
                ClientId = message.Client.Id,
                Text = message.Text,
                WorkerId = message.Worker.Id,
                SendDate = DateTime.Now,
                ChatId = message.Chat.Id
            };

            _ent.Message.Add(messageData);
            await _ent.SaveChangesAsync();

            return Request.CreateResponse(System.Net.HttpStatusCode.OK);
        }

        public IHttpActionResult Get([FromUri]int chatId, string secretKey)
        {
            return Ok(_ent.Message.Where(x => x.ChatId == chatId && x.Chat.SecretKey == secretKey).ToList().ConvertAll(x => new MessageModel(x)));
        }
    }
}