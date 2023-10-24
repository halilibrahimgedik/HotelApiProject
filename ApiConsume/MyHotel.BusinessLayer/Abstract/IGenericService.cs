using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        List<T> TGetAll();

        T TGetById(int id);

        void TDelete(T entity);

        void TUpdate(T entity);

        void TAdd(T entity);
    }
}
