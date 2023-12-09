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
        public EfCoreSendMessageRepository(Context db) : base(db)
        {
            
        }
    }
}
