using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EldocCodeApi.Models
{
    public class MessageModel
    {
        public MessageModel(Message message = null)
        {
            if (message != null)
            {
                Id = message.Id;
                Text = message.Text;
                SendDate = (DateTime)message.SendDate;
                Client = new ClientModel(message.Client);
                Worker = new WorkerModel(message.Worker);
            }
        }
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime SendDate { get; set; }
        public ClientModel Client { get; set; }
        public WorkerModel Worker { get; set; }
        public ChatModel Chat { get; set; }
    }
}