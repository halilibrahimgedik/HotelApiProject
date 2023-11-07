using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.EntityLayer.Concrete
{
    public class Guest
    {
        public int GuestId { get; set; }

        public string GuestIdentityNo { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public byte Age { get; set; }
    }
}
