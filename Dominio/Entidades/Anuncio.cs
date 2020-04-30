using Dominio.Enumeradores;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class Anuncio
    {
        public int Id { get; private set; }
        public decimal ValorDeCompra { get; private set; }
        public decimal ValorDeVenda { get; private set; }
        public ECor Cor { get; private set; }
        public ETipoDeCombustivel TipoDeCombustivel { get; private set; }
        public DateTime? DataDeVenda { get; private set; }
        public int ModeloId { get; private set; }
        public virtual Modelo Modelo { get; private set; }

        [NotMapped]
        public decimal Lucro { get { return ValorDeVenda - ValorDeCompra; } }

        protected Anuncio() { }

        public Anuncio(int modeloId,
            decimal valorDeCompra,
            decimal valorDeVenda,
            ECor cor,
            ETipoDeCombustivel tipoDeCombustivel,
            DateTime? dataDeVenda)
        {
            ModeloId = modeloId;
            ValorDeCompra = valorDeCompra;
            ValorDeVenda = valorDeVenda;
            Cor = cor;
            TipoDeCombustivel = tipoDeCombustivel;
            DataDeVenda = dataDeVenda;
        }

        public void AlterarModelo(int modeloId)
        {
            ModeloId = modeloId;
        }

        public void AlterarValorDeCompra(decimal valorDeCompra)
        {
            ValorDeCompra = valorDeCompra;
        }

        public void AlterarValorDeVenda(decimal valorDeVenda)
        {
            ValorDeVenda = valorDeVenda;
        }

        public void AlterarCor(ECor cor)
        {
            Cor = cor;
        }
        public void AlterarTipoDeCombustivel(ETipoDeCombustivel tipoDeCombustivel)
        {
            TipoDeCombustivel = tipoDeCombustivel;
        }
        public void AlterarDataDeVenda(DateTime? dataDeVenda)
        {
            DataDeVenda = dataDeVenda;
        }
    }
}
