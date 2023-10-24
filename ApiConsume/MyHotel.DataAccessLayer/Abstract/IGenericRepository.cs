using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.DataAccessLayer.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();

        T GetById(int id);

        void Delete(T entity);

        void Update(T entity);

        void Add(T entity);
    }
}
