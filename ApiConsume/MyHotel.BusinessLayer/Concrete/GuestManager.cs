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
    public class GuestManager : IGuestService
    {
        private readonly IGuestRepository guestRepository;

        public GuestManager(IGuestRepository guestRepository)
        {
            this.guestRepository = guestRepository;
        }


        public void TAdd(Guest entity)
        {
            guestRepository.Add(entity);
        }

        public void TDelete(Guest entity)
        {
            guestRepository.Delete(entity);
        }

        public List<Guest> TGetAll()
        {
           return guestRepository.GetAll();
        }

        public Guest TGetById(int id)
        {
           return guestRepository.GetById(id);
        }

        public void TUpdate(Guest entity)
        {
            guestRepository.Update(entity);
        }
    }
}
