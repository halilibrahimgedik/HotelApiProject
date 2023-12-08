using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.EntityLayer.Concrete
{
    public class Contact
    {
        public int ContactId { get; set; }

        public string Name { get; set; }

        public string Mail { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public string Date { get; set; } = DateTime.UtcNow.ToString();
    }
}
