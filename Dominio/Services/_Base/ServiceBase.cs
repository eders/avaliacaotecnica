using Dominio.Interfaces.Data;

namespace Dominio.Services._Base
{

    public class ServiceBase
    {
        internal readonly IUnitOfWork _unitOfWork;

        public ServiceBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
