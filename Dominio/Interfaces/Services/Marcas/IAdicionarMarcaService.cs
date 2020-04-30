using Dominio.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces.Services.Marcas
{
    public interface IAdicionarMarcaService 
    {
        void Execute(MarcaDto marca);
    }
}
