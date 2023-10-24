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
    public class SubscribeManager : ISubscribeService
    {
        private readonly ISubscribeRepository subscribeRepository;
        public SubscribeManager(ISubscribeRepository subscribeRepository)
        {
            this.subscribeRepository = subscribeRepository;
        }



        public void TAdd(Subscribe entity)
        {
            subscribeRepository.Add(entity);
        }

        public void TDelete(Subscribe entity)
        {
            subscribeRepository.Delete(entity);
        }

        public List<Subscribe> TGetAll()
        {
            return subscribeRepository.GetAll();
        }

        public Subscribe TGetById(int id)
        {
            return subscribeRepository.GetById(id);
        }

        public void TUpdate(Subscribe entity)
        {
            subscribeRepository.Update(entity);
        }
    }
}
