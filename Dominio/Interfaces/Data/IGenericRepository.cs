using System.Linq;

namespace Dominio.Interfaces.Data
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> Query();
        T GetById(int id);
        T Add(T entity);
        void Delete(T t);
        T Update(T updated);
    }
}
