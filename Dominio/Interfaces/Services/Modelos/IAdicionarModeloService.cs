using Dominio.Dtos;

namespace Dominio.Interfaces.Services.Modelos
{
    public interface IAdicionarModeloService
    {
        void Execute(ModeloDto modelo);
    }
}
