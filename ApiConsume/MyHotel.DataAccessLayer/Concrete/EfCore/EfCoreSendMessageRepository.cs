using MyHotel.DataAccessLayer.Abstract;
using MyHotel.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.DataAccessLayer.Concrete.EfCore
{
    public class EfCoreSendMessageRepository : GenericRepository<SendMessage>, ISendMessageRepository
    {
        private readonly Context _context;
        public EfCoreSendMessageRepository(Context db) : base(db)
        {
            _context = db;
        }

        public int GetSentMessageCount()
        {
            return _context.SendMessages.Count();
        }
    }
}
