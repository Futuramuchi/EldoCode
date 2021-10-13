using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EldocCodeApi.Models
{
    public class OrderModel
    {
        public OrderModel(Order order = null)
        {
            if (order != null)
            {
                Id = order.Id;
                Client = new ClientModel(order.Client);
                Worker = new WorkerModel(order.Worker);
                DateCreated = (DateTime)order.DateCreated;
                Status = new StatusModel(order.Status);
                Notification = new NotificationModel(order.Notification);
            } 
        }

        public int Id { get; set; }
        public ClientModel Client { get; set; }
        public WorkerModel Worker { get; set; }
        public DateTime DateCreated { get; set; }
        public StatusModel Status { get; set; }
        public NotificationModel Notification { get; set; }
    }
}