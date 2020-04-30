using Dominio.Dtos;

namespace Dominio.Interfaces.Services.Anuncios
{
    public interface IAlterarAnuncioService
    {
        void Execute(int id, AnuncioDto anuncio);
    }
}
