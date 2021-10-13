using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldoCodeDesktop.Model
{
    public class MessageModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime SendDate { get; set; }
        public ClientModel Client { get; set; }
        public WorkerModel Worker { get; set; }
        public ChatModel Chat { get; set; }
    }
}
