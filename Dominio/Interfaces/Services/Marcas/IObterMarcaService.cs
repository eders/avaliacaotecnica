using Dominio.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces.Services.Marcas
{
    public interface IObterMarcaService
    {
        MarcaDto PorId(int id);
    }
}
