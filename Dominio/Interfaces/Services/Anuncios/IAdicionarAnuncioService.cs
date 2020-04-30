using Dominio.Dtos;

namespace Dominio.Interfaces.Services.Anuncios
{
    public interface IAdicionarAnuncioService
    {
        void Execute(AnuncioDto anuncio);
    }
}
