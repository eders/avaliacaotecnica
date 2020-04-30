using Dominio.Dtos;

namespace Dominio.Interfaces.Services.Anuncios
{
    public interface IObterAnuncioService
    {
        AnuncioDto PorId(int id);
    }
}
