using Dominio.Interfaces.Data;
using Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infra.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AvaliacaoContexto _context;
        private readonly IUnitOfWork _unitOfWork;

        public GenericRepository(AvaliacaoContexto context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(context);
        }

        public IQueryable<T> Query()
        {
            return _context.Set<T>().AsQueryable();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public void Delete(T t)
        {
            _context.Set<T>().Remove(t);
        }

        public T Update(T updated)
        {
            if (updated == null)
            {
                return null;
            }

            _context.Set<T>().Attach(updated);
            _context.Entry(updated).State = EntityState.Modified;

            return updated;
        }
    }
}
