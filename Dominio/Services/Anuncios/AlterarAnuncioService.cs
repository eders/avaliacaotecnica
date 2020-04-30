using Dominio.Dtos;
using Dominio.Entidades;
using Dominio.Interfaces.Data;
using Dominio.Interfaces.Services.Anuncios;
using Dominio.Services._Base;

namespace Dominio.Services.Anuncios
{
    public class AlterarAnuncioService : ServiceBase, IAlterarAnuncioService
    {
        public AlterarAnuncioService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void Execute(int id, AnuncioDto anuncio)
        {
            var anuncioAntigo = _unitOfWork.Repository<Anuncio>().GetById(id);

            if (anuncioAntigo != null)
            {
                anuncioAntigo.AlterarCor(anuncio.Cor);
                anuncioAntigo.AlterarDataDeVenda(anuncio.DataDeVenda);
                anuncioAntigo.AlterarModelo(anuncio.ModeloId);
                anuncioAntigo.AlterarTipoDeCombustivel(anuncio.TipoDeCombustivel);
                anuncioAntigo.AlterarValorDeCompra(anuncio.ValorDeCompra);
                anuncioAntigo.AlterarValorDeVenda(anuncio.ValorDeVenda);

                _unitOfWork.Repository<Anuncio>().Update(anuncioAntigo);
            }
        }
    }
}
