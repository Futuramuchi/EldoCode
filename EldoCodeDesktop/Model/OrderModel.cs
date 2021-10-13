using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldoCodeDesktop.Model
{
    public class OrderModel
    {
        public int Id { get; set; }
        public ClientModel Client { get; set; }
        public WorkerModel Worker { get; set; }
        public DateTime DateCreated { get; set; }
        public StatusModel Status { get; set; }
        public NotificationModel Notification { get; set; }
    }
}
