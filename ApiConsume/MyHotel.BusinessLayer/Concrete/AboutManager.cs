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
    public class AboutManager : IAboutService
    {
        private readonly IAboutRepository aboutRepository;

        public AboutManager(IAboutRepository aboutRepository)
        {
            this.aboutRepository = aboutRepository;
        }


        public void TAdd(About entity)
        {
            aboutRepository.Add(entity);
        }

        public void TDelete(About entity)
        {
            aboutRepository.Delete(entity);
        }

        public List<About> TGetAll()
        {
            return aboutRepository.GetAll();
        }

        public About TGetById(int id)
        {
            return aboutRepository.GetById(id);
        }

        public void TUpdate(About entity)
        {
            aboutRepository.Update(entity);
        }
    }
}
