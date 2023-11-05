using MyHotel.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.BusinessLayer.Abstract
{
    public interface IBookingService : IGenericService<Booking>
    {
        public void TChangeStatusWithApproved(Booking booking);
        void TChangeStatusToApprovedWithId(int id);
    }
}
