using MyHotel.DataAccessLayer.Abstract;
using MyHotel.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.DataAccessLayer.Concrete.EfCore
{
    public class EfCoreGuestRepository : GenericRepository<Guest>, IGuestRepository
    {
        private readonly Context db;

        public EfCoreGuestRepository(Context db) : base(db)
        {
            this.db = db;
        }

    }
}
