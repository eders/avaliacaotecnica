using Dominio.Dtos;
using Dominio.Interfaces.Data;
using Dominio.Interfaces.Services.Marcas;
using Dominio.Services._Base;
using Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Dominio.Services.Marcas
{
    public class ListarMarcaService : ServiceBase, IListarMarcaService
    {
        public ListarMarcaService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public List<MarcaDto> Execute()
        {
            return _unitOfWork.Repository<Marca>().Query()
                  .Select(x => new MarcaDto
                  {
                      Id = x.Id,
                      Nome = x.Nome
                  }).ToList();
        }
    }
}
