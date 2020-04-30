using Dominio.Dtos;
using Dominio.Entidades;
using Dominio.Interfaces.Data;
using Dominio.Interfaces.Services.Anuncios;
using Dominio.Services._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Services.Anuncios
{
    public class ObterAnuncioService : ServiceBase, IObterAnuncioService
    {
        public ObterAnuncioService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public AnuncioDto PorId(int id)
        {
            return _unitOfWork.Repository<Anuncio>().Query()
                .Where(x => x.Id == id)
                 .Select(x => new AnuncioDto
                 {
                     Id = x.Id,
                     MarcaId = x.Modelo.MarcaId,
                     ModeloId = x.ModeloId,
                     Cor = x.Cor,
                     DataDeVenda = x.DataDeVenda,
                     NomeMarca = x.Modelo.Marca.Nome,
                     NomeModelo = x.Modelo.Nome +"-"+ x.Modelo.Ano,
                     TipoDeCombustivel = x.TipoDeCombustivel,
                     ValorDeCompra = x.ValorDeCompra,
                     ValorDeVenda = x.ValorDeVenda
                 }).FirstOrDefault();
        }
    }
}
