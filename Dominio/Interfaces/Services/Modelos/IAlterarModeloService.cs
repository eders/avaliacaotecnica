using Dominio.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces.Services.Modelos
{
    public interface IAlterarModeloService
    {
        void Execute(int id, ModeloDto modelo);
    }
}
