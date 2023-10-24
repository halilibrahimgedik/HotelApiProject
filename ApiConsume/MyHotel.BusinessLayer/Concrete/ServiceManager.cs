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
    public class ServiceManager : IServiceService
    {
        private readonly IServiceRepository serviceRepository;
        public ServiceManager(IServiceRepository serviceRepository)
        {
            this.serviceRepository = serviceRepository;
        }



        public void TAdd(Service entity)
        {
            serviceRepository.Add(entity);
        }

        public void TDelete(Service entity)
        {
            serviceRepository.Delete(entity);
        }

        public List<Service> TGetAll()
        {
            return serviceRepository.GetAll();
        }

        public Service TGetById(int id)
        {
            return serviceRepository.GetById(id);
        }

        public void TUpdate(Service entity)
        {
            serviceRepository.Update(entity);
        }
    }
}
