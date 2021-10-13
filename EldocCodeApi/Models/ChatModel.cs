using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EldocCodeApi.Models
{
    public class ChatModel
    {
        public ChatModel(Chat chat = null)
        {
            if (chat != null)
            {
                Id = chat.Id;
                ProductOrder = new ProductOrderModel(chat.ProductOrder);
                DateCreated = (DateTime)chat.DateCreated;
                SecretKey = chat.SecretKey;
            }
        }
        public int Id { get; set; }
        public ProductOrderModel ProductOrder { get; set; }
        public DateTime DateCreated { get; set; }
        public string SecretKey { get; set; }
    }
}