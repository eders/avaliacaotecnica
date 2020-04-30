using Dominio.Dtos;
using Dominio.Entidades;
using Dominio.Interfaces.Data;
using Dominio.Interfaces.Services.Modelos;
using Dominio.Services._Base;

namespace Dominio.Services.Modelos
{
    public class AlterarModeloService : ServiceBase, IAlterarModeloService
    {
        public AlterarModeloService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void Execute(int id, ModeloDto modelo)
        {
            var modeloAntigo = _unitOfWork.Repository<Modelo>().GetById(id);

            if (modeloAntigo != null)
            {
                modeloAntigo.AlterarNome(modelo.Nome);
                modeloAntigo.AlterarAno(modelo.Ano);
                modeloAntigo.AlterarMarca(modelo.MarcaId);

                _unitOfWork.Repository<Modelo>().Update(modeloAntigo);
            }
        }
    }
}
