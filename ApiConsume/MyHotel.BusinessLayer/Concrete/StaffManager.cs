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
    public class StaffManager : IStaffService
    {
        private readonly IStaffRepository staffRepository;
        public StaffManager(IStaffRepository staffRepository)
        {
            this.staffRepository = staffRepository;
        }


        public void TAdd(Staff entity)
        {
            staffRepository.Add(entity);
        }

        public void TDelete(Staff entity)
        {
            staffRepository.Delete(entity);
        }

        public List<Staff> TGetAll()
        {
            return staffRepository.GetAll();
        }

        public Staff TGetById(int id)
        {
            return staffRepository.GetById(id);
        }

        public void TUpdate(Staff entity)
        {
            staffRepository.Update(entity);
        }
    }
}
