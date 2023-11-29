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
    public class ContactManager : IContactService
    {
        private readonly IContactRepository contactRepository;

        public ContactManager(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public void TAdd(Contact entity)
        {
            contactRepository.Add(entity);
        }

        public void TDelete(Contact entity)
        {
            contactRepository.Delete(entity);
        }

        public List<Contact> TGetAll()
        {
            return contactRepository.GetAll();
        }

        public Contact TGetById(int id)
        {
            return contactRepository.GetById(id);
        }

        public void TUpdate(Contact entity)
        {
            contactRepository.Update(entity);
        }
    }
}
