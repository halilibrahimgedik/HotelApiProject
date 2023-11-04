using MyHotel.DataAccessLayer.Abstract;
using MyHotel.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.DataAccessLayer.Concrete.EfCore
{
    public class EfCoreBookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        private readonly Context db;

        public EfCoreBookingRepository(Context db) : base(db)
        {
            this.db = db;
        }

    }
}
