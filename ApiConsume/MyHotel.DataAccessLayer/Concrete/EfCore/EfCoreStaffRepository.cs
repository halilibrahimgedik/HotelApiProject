using MyHotel.DataAccessLayer.Abstract;
using MyHotel.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.DataAccessLayer.Concrete.EfCore
{
    public class EfCoreStaffRepository : GenericRepository<Staff>, IStaffRepository
    {
        private readonly Context db;
        public EfCoreStaffRepository(Context db) : base(db)
        {
            this.db = db;
        }


    }
}
