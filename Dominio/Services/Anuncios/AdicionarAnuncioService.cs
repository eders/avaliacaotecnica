using Dominio.Dtos;
using Dominio.Entidades;
using Dominio.Interfaces.Data;
using Dominio.Interfaces.Services.Anuncios;
using Dominio.Services._Base;

namespace Dominio.Services.Anuncios
{
    public class AdicionarAnuncioService : ServiceBase, IAdicionarAnuncioService
    {
        public AdicionarAnuncioService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void Execute(AnuncioDto anuncio)
        {
            var novoAnuncio = new Anuncio(anuncio.ModeloId,
                anuncio.ValorDeCompra,
                anuncio.ValorDeVenda,
                anuncio.Cor,
                anuncio.TipoDeCombustivel,
                anuncio.DataDeVenda);

            _unitOfWork.Repository<Anuncio>().Add(novoAnuncio);
        }
    }
}
