using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShoeWorld.Dal
{
    public interface IShoeWorldRepository<T>
    {
        List<T> GetAll();
        T GetDetails(int id);
        void insert(T item);
        void update(T item);
        void delete(int item);
        int SaveChanges();

    }
}
