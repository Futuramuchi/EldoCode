using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldoCodeDesktop.Model
{
    public class ChatModel
    {
        public int Id { get; set; }
        public ProductOrderModel ProductOrder { get; set; }
        public DateTime DateCreated { get; set; }
        public string SecretKey { get; set; }
    }
}
