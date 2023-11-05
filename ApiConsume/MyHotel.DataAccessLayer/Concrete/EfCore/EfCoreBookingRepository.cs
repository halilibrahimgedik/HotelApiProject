using MyHotel.DataAccessLayer.Abstract;
using MyHotel.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.DataAccessLayer.Concrete.EfCore
{
    public class EfCoreBookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        private readonly Context db;

        public EfCoreBookingRepository(Context db) : base(db)
        {
            this.db = db;
        }

        public void ChangeStatusWithApproved(Booking booking)
        {
            var reservation = db.Bookings.Where(x => x.BookingId == booking.BookingId).FirstOrDefault();

            if (reservation != null)
            {
                reservation.Status = "Onaylandı";
                db.Update(reservation);
                db.SaveChanges();
            }
        }

        public void ChangeStatusToApprovedWithId(int id)
        {
            var reservation = db.Bookings.Find(id);

            if (reservation != null)
            {
                reservation.Status = "Onaylandı";
                db.Update(reservation);
                db.SaveChanges();
            }
        }
    }
}
