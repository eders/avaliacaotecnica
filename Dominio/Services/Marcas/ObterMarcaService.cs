using Dominio.Dtos;
using Dominio.Interfaces.Data;
using Dominio.Interfaces.Services.Marcas;
using Dominio.Services._Base;
using Entidades;
using System.Linq;

namespace Dominio.Services.Marcas
{
    public class ObterMarcaService : ServiceBase, IObterMarcaService
    {
        public ObterMarcaService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public MarcaDto PorId(int id)
        {
            return _unitOfWork.Repository<Marca>().Query()
                .Where(x => x.Id == id)
                 .Select(x => new MarcaDto
                 {
                     Id = x.Id,
                     Nome = x.Nome
                 }).FirstOrDefault();
        }
    }
}
