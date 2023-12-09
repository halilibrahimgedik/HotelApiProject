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
    public class SendMessageManager : ISendMessageService
    {
        private readonly ISendMessageRepository sendMessageRepository;

        public SendMessageManager(ISendMessageRepository sendMessageRepository)
        {
            this.sendMessageRepository = sendMessageRepository;
        }



        public void TAdd(SendMessage entity)
        {
            sendMessageRepository.Add(entity);
        }

        public void TDelete(SendMessage entity)
        {
            sendMessageRepository.Delete(entity);
        }

        public List<SendMessage> TGetAll()
        {
            return sendMessageRepository.GetAll();
        }

        public SendMessage TGetById(int id)
        {
            return sendMessageRepository.GetById(id);
        }

        public void TUpdate(SendMessage entity)
        {
            sendMessageRepository.Update(entity);
        }
    }
}
