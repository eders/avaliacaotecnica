using System.Threading.Tasks;

namespace Dominio.Interfaces.Data
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> Repository<T>() where T : class;
        Task<int> Commit();
        void Rollback();
    }
}
