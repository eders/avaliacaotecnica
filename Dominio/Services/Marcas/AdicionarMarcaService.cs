using Dominio.Dtos;
using Dominio.Interfaces.Data;
using Dominio.Interfaces.Services.Marcas;
using Dominio.Services._Base;
using Entidades;

namespace Dominio.Services.Marcas
{
    public class AdicionarMarcaService : ServiceBase, IAdicionarMarcaService
    {
        public AdicionarMarcaService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void Execute(MarcaDto marca)
        {
            var novaMarca = new Marca(marca.Nome);

            _unitOfWork.Repository<Marca>().Add(novaMarca);
        }
    }
}
