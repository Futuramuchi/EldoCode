using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EldocCodeApi.Models
{
    public class NotificationModel
    {
        public NotificationModel(Notification notification = null)
        {
            if (notification != null)
            {
                Id = notification.Id;
                Zone = notification.Zone;
            }
        }
        public int Id { get; set; }
        public string Zone { get; set; }
    }
}
