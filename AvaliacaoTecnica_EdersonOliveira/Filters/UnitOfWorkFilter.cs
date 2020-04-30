using Dominio.Interfaces.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace AvaliacaoTecnica_EdersonOliveira.Filters
{
    public class UnitOfWorkFilter : IAsyncResultFilter
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkFilter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            try
            {
                await _unitOfWork.Commit();

                await next();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();

                throw;
            }
        }
    }
}
