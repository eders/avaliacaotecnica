using Dominio.Dtos;
using Dominio.Entidades;
using Dominio.Interfaces.Data;
using Dominio.Interfaces.Services.Modelos;
using Dominio.Services._Base;
using System.Collections.Generic;
using System.Linq;

namespace Dominio.Services.Modelos
{
    public class ObterModeloService : ServiceBase, IObterModeloService
    {
        public ObterModeloService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public ModeloDto PorId(int id)
        {
            return _unitOfWork.Repository<Modelo>().Query()
                .Where(x=>x.Id ==  id)
                 .Select(x => new ModeloDto
                 {
                     Id = x.Id,
                     Nome = x.Nome,
                     Ano = x.Ano,
                     MarcaId = x.MarcaId
                 }).FirstOrDefault();
        }

        public List<ModeloDto> PorMarca(int marcaId)
        {
            return _unitOfWork.Repository<Modelo>().Query()
                .Where(x => x.MarcaId == marcaId)
                 .Select(x => new ModeloDto
                 {
                     Id = x.Id,
                     Nome = x.Nome,
                     Ano = x.Ano,
                     MarcaId = x.MarcaId
                 }).ToList();
        }
    }
}
