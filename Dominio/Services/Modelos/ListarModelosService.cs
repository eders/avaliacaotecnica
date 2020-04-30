using Dominio.Dtos;
using Dominio.Entidades;
using Dominio.Interfaces.Data;
using Dominio.Interfaces.Services.Modelos;
using Dominio.Services._Base;
using System.Collections.Generic;
using System.Linq;

namespace Dominio.Services.Modelos
{
    public class ListarModelosService : ServiceBase, IListarModelosService
    {
        public ListarModelosService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public List<ModeloDto> Execute()
        {
            return _unitOfWork.Repository<Modelo>().Query()
                  .Select(x => new ModeloDto
                  {
                      Id = x.Id,
                      Ano = x.Ano,
                      Nome = x.Nome,
                      NomeMarca =  x.Marca.Nome
                  }).ToList();
        }
    }
}
