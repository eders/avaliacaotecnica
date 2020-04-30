using Dominio.Entidades;
using Dominio.Interfaces.Data;
using Dominio.Interfaces.Services.Anuncios;
using Dominio.Services._Base;

namespace Dominio.Services.Anuncios
{
    public class DeletarAnuncioService : ServiceBase, IDeletarAnuncioService
    {
        public DeletarAnuncioService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void Execute(int id)
        {
            var anuncio = _unitOfWork.Repository<Anuncio>().GetById(id);

            if (anuncio != null)
            {
                _unitOfWork.Repository<Anuncio>().Delete(anuncio);
            }
        }
    }
}
