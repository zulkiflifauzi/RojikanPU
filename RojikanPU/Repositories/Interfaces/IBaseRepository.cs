using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojikanPU.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        void Create(T entity);

        List<T> GetAll();

        T GetById(int id);

        T Edit(T entity);

        void Delete(int id);
    }
}
