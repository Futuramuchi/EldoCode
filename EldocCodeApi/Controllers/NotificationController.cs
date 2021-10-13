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
    public class NotificationController : ApiController
    {
        private EldoCodeEntities _ent;

        public NotificationController()
        {
            _ent = new EldoCodeEntities();
        }

        public async Task<HttpResponseMessage> Post([FromBody] NotificationModel notification)
        {
            Notification notificationData = new Notification() { Zone = notification.Zone };

            _ent.Notification.Add(notificationData);
            await _ent.SaveChangesAsync();

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, notificationData.Id);

        }
    }
}