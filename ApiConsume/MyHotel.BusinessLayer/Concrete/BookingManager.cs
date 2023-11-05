using MyHotel.BusinessLayer.Abstract;
using MyHotel.DataAccessLayer.Abstract;
using MyHotel.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.BusinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingRepository bookingRepository;
        public BookingManager(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }

        public void TChangeStatusToApprovedWithId(int id)
        {
            bookingRepository.ChangeStatusToApprovedWithId(id);
        }

        public void TAdd(Booking entity)
        {
            bookingRepository.Add(entity);
        }

        public void TChangeStatusWithApproved(Booking booking)
        {
            bookingRepository.ChangeStatusWithApproved(booking);
        }

        public void TDelete(Booking entity)
        {
            bookingRepository.Delete(entity);
        }

        public List<Booking> TGetAll()
        {
            return bookingRepository.GetAll();
        }

        public Booking TGetById(int id)
        {
            return bookingRepository.GetById(id);
        }

        public void TUpdate(Booking entity)
        {
            bookingRepository.Update(entity);
        }
    }
}
