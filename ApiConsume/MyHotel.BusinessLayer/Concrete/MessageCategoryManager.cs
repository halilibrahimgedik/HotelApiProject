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
    public class MessageCategoryManager : IMessageCategoryService
    {
        private readonly IMessageCategoryRepository messageCategoryRepository;
        public MessageCategoryManager(IMessageCategoryRepository messageCategoryRepository)
        {
            this.messageCategoryRepository = messageCategoryRepository;
        }


        public void TAdd(MessageCategory entity)
        {
            messageCategoryRepository.Add(entity);
        }

        public void TDelete(MessageCategory entity)
        {
            messageCategoryRepository.Delete(entity);
        }

        public List<MessageCategory> TGetAll()
        {
            return messageCategoryRepository.GetAll();
        }

        public MessageCategory TGetById(int id)
        {
            return messageCategoryRepository.GetById(id);
        }

        public void TUpdate(MessageCategory entity)
        {
            messageCategoryRepository.Update(entity);
        }
    }
}
