using Dominio.Entidades;
using Dominio.Enumeradores;
using System;
using System.Collections.Generic;
using System.Text;
using Testes.Extensions;

namespace Testes.Builders
{
    public class AnuncioBuilder
    {
        private Anuncio _anuncio;

        public AnuncioBuilder()
        {
            var modeloId = 1;
            var valorDeCompra = 1;
            var valorDeVenda = 1;
            var cor = ECor.amarelo;
            var tipoDeCombustivel = ETipoDeCombustivel.Diesel;
            var dataDeVenda = DateTime.Now;

            _anuncio = new Anuncio(modeloId, valorDeCompra, valorDeVenda, cor, tipoDeCombustivel, dataDeVenda);
        }

        public AnuncioBuilder ComValorDeCompra(decimal valorDeCompra)
        {
            ObjectExtensions.SetPrivateValue(_anuncio, "ValorDeCompra", valorDeCompra);

            return this;
        }

        public AnuncioBuilder ComValorDeVenda(decimal valorDeVenda)
        {
            ObjectExtensions.SetPrivateValue(_anuncio, "ValorDeVenda", valorDeVenda);

            return this;
        }

        public Anuncio Build() => _anuncio;
    }
}
