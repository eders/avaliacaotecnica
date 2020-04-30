using Dominio.Dtos;
using Dominio.Entidades;
using Dominio.Interfaces.Data;
using Dominio.Interfaces.Services.Anuncios;
using Dominio.Services._Base;
using System.Collections.Generic;
using System.Linq;

namespace Dominio.Services.Anuncios
{
    public class ListarAnuncioService : ServiceBase, IListarAnuncioService
    {
        public ListarAnuncioService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public List<AnuncioDto> Execute()
        {
            return _unitOfWork.Repository<Anuncio>().Query()
                  .Select(x => new AnuncioDto
                  {
                      Id = x.Id,
                      Cor = x.Cor,
                      ModeloId = x.ModeloId,
                      ValorDeCompra = x.ValorDeCompra,
                      ValorDeVenda = x.ValorDeVenda,
                      TipoDeCombustivel = x.TipoDeCombustivel,
                      DataDeVenda = x.DataDeVenda,
                      MarcaId = x.Modelo.MarcaId,
                      NomeMarca = x.Modelo.Marca.Nome,
                      NomeModelo = x.Modelo.Nome +"-"+ x.Modelo.Ano
                  }).ToList();
        }
    }
}
