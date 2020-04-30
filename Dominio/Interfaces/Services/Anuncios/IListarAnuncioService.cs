using Dominio.Dtos;
using System.Collections.Generic;

namespace Dominio.Interfaces.Services.Anuncios
{
    public interface IListarAnuncioService
    {
        List<AnuncioDto> Execute();
    }
}
