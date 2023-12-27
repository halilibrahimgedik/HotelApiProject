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
    public class WorkLocationManager : IWorkLocationService
    {
        private readonly IWorkLocationRepository workLocationRepository;

        public WorkLocationManager(IWorkLocationRepository workLocationRepository)
        {
            this.workLocationRepository = workLocationRepository;
        }


        public void TAdd(WorkLocation entity)
        {
            workLocationRepository.Add(entity);
        }

        public void TDelete(WorkLocation entity)
        {
            workLocationRepository.Delete(entity);
        }

        public List<WorkLocation> TGetAll()
        {
            return workLocationRepository.GetAll();
        }

        public WorkLocation TGetById(int id)
        {
            return workLocationRepository.GetById(id);
        }

        public void TUpdate(WorkLocation entity)
        {
            workLocationRepository.Update(entity);
        }
    }
}
