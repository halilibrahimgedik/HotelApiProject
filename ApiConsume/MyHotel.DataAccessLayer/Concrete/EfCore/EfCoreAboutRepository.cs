using MyHotel.DataAccessLayer.Abstract;
using MyHotel.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.DataAccessLayer.Concrete.EfCore
{
    public class EfCoreAboutRepository : GenericRepository<About>, IAboutRepository
    {
        private readonly Context db;

        public EfCoreAboutRepository(Context db) : base(db)
        {
            this.db = db;
        }
    }
}
