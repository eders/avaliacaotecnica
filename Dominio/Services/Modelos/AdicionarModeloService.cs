using Dominio.Dtos;
using Dominio.Entidades;
using Dominio.Interfaces.Data;
using Dominio.Interfaces.Services.Modelos;
using Dominio.Services._Base;

namespace Dominio.Services.Modelos
{
    public class AdicionarModeloService : ServiceBase, IAdicionarModeloService
    {
        public AdicionarModeloService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void Execute(ModeloDto modelo)
        {
            var novoModelo = new Modelo(modelo.MarcaId, modelo.Nome, modelo.Ano);

            _unitOfWork.Repository<Modelo>().Add(novoModelo);
        }
    }
}
