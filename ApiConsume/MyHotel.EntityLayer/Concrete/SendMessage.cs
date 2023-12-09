using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.EntityLayer.Concrete
{
    public class SendMessage
    {
        public int SendMessageId { get; set; }

        public string ReceiverName { get; set; }

        public string ReceiverMail { get; set; }

        public string SenderName { get; set; }

        public string SenderMail { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Date { get; set; } = DateTime.UtcNow.ToString();
    }
}
