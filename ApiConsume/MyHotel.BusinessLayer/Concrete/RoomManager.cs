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
    public class RoomManager : IRoomService
    {
        private readonly IRoomRepository roomRepository;
        public RoomManager(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }


        public void TAdd(Room entity)
        {
            roomRepository.Add(entity);
        }

        public void TDelete(Room entity)
        {
            roomRepository.Delete(entity);
        }

        public List<Room> TGetAll()
        {
            return roomRepository.GetAll();
        }

        public Room TGetById(int id)
        {
            return roomRepository.GetById(id);
        }

        public void TUpdate(Room entity)
        {
            roomRepository.Update(entity);
        }
    }
}
