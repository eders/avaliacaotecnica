using Dominio.Entidades;
using Dominio.Interfaces.Data;
using Dominio.Interfaces.Services.Modelos;
using Dominio.Services._Base;

namespace Dominio.Services.Modelos
{
    public class DeletarModeloService : ServiceBase, IDeletarModeloService
    {
        public DeletarModeloService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public void Execute(int id)
        {
            var modelo = _unitOfWork.Repository<Modelo>().GetById(id);

            if (modelo != null)
            {
                _unitOfWork.Repository<Modelo>().Delete(modelo);
            }
        }
    }
}
