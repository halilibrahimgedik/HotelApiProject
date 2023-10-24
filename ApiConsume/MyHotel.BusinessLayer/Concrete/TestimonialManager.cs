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
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialRepository testimonialRepository;
        public TestimonialManager(ITestimonialRepository testimonialRepository)
        {
            this.testimonialRepository = testimonialRepository;
        }



        public void TAdd(Testimonial entity)
        {
            testimonialRepository.Add(entity);
        }

        public void TDelete(Testimonial entity)
        {
            testimonialRepository.Delete(entity);
        }

        public List<Testimonial> TGetAll()
        {
            return testimonialRepository.GetAll();
        }

        public Testimonial TGetById(int id)
        {
            return testimonialRepository.GetById(id);
        }

        public void TUpdate(Testimonial entity)
        {
            testimonialRepository.Update(entity);
        }
    }
}
