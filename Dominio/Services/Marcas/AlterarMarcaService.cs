using Dominio.Dtos;
using Dominio.Interfaces.Data;
using Dominio.Interfaces.Services.Marcas;
using Dominio.Services._Base;
using Entidades;

namespace Dominio.Services.Marcas
{
    public class AlterarMarcaService : ServiceBase, IAlterarMarcaService
    {
        public AlterarMarcaService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public void Execute(int id,MarcaDto marca)
        {
            var marcaAntiga = _unitOfWork.Repository<Marca>().GetById(id);

            if (marcaAntiga != null)
            {
                marcaAntiga.AlterarNome(marca.Nome);

                _unitOfWork.Repository<Marca>().Update(marcaAntiga);
            }
        }
    }
}
