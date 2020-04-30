using Dominio.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces.Services.Modelos
{
    public interface IObterModeloService
    {
        ModeloDto PorId(int id);
        List<ModeloDto> PorMarca(int marcaId);
    }
}
