using Dominio.Interfaces.Data;
using Dominio.Interfaces.Services.Marcas;
using Dominio.Services._Base;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Services.Marcas
{
    public class DeletarMarcaService : ServiceBase, IDeletarMarcaService
    {
        public DeletarMarcaService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void Execute(int id)
        {

            var marca = _unitOfWork.Repository<Marca>().GetById(id);

            if (marca != null)
            {
                _unitOfWork.Repository<Marca>().Delete(marca);
            }
        }
    }
}
