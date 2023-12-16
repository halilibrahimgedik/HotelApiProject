using MyHotel.DataAccessLayer.Abstract;
using MyHotel.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.DataAccessLayer.Concrete.EfCore
{
    public class EfCoreContactRepository : GenericRepository<Contact>, IContactRepository
    {
        private readonly Context context;
        public EfCoreContactRepository(Context db) : base(db)
        {
            context = db;
        }


        public int GetContactCount()
        {
            return context.Contacts.Count();
            
        }
    }
}
