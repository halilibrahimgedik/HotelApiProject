using MyHotel.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.DataAccessLayer.Abstract
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        void ChangeStatusWithApproved(Booking booking);

        void ChangeStatusToApprovedWithId(int id);
    }
}
