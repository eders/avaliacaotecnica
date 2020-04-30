using Dominio.Entidades;
using Dominio.Enumeradores;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Testes.Builders;

namespace Testes.Entidades
{
    public class AnuncioTestes
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DeveCriarUmaMarca()
        {
            var modeloId = 1;
            var valorDeCompra = 1;
            var valorDeVenda = 1;
            var cor = ECor.amarelo;
            var tipoDeCombustivel = ETipoDeCombustivel.Diesel;
            var dataDeVenda = DateTime.Now;

            var anuncio = new Anuncio(modeloId,
                valorDeCompra,
                valorDeVenda,
                cor,
                tipoDeCombustivel,
                dataDeVenda);

            Assert.AreEqual(modeloId, anuncio.ModeloId);
            Assert.AreEqual(valorDeCompra, anuncio.ValorDeCompra);
            Assert.AreEqual(valorDeVenda, anuncio.ValorDeVenda);
            Assert.AreEqual(cor, anuncio.Cor);
            Assert.AreEqual(tipoDeCombustivel, anuncio.TipoDeCombustivel);
            Assert.AreEqual(dataDeVenda, anuncio.DataDeVenda);
        }

        [Test]
        public void DeveAlterarOModelo()
        {
            var valorEsperado = 111;

            var anuncio = new AnuncioBuilder().Build();
            anuncio.AlterarModelo(valorEsperado);

            Assert.AreEqual(valorEsperado, anuncio.ModeloId);
        }

        [Test]
        public void DeveAlterarOValorDeCompra()
        {
            var valorEsperado = 111;

            var anuncio = new AnuncioBuilder().Build();
            anuncio.AlterarValorDeCompra(valorEsperado);

            Assert.AreEqual(valorEsperado, anuncio.ValorDeCompra);
        }

        [Test]
        public void DeveAlterarOValorDeVenda()
        {
            var valorEsperado = 111;

            var anuncio = new AnuncioBuilder().Build();
            anuncio.AlterarValorDeVenda(valorEsperado);

            Assert.AreEqual(valorEsperado, anuncio.ValorDeVenda);
        }

        [Test]
        public void DeveAlterarACor()
        {
            var valorEsperado = ECor.branco;

            var anuncio = new AnuncioBuilder().Build();
            anuncio.AlterarCor(valorEsperado);

            Assert.AreEqual(valorEsperado, anuncio.Cor);
        }

        [Test]
        public void DeveAlterarOTipoDeCombustivel()
        {
            var valorEsperado = ETipoDeCombustivel.Etanol;

            var anuncio = new AnuncioBuilder().Build();
            anuncio.AlterarTipoDeCombustivel(valorEsperado);

            Assert.AreEqual(valorEsperado, anuncio.TipoDeCombustivel);
        }

        [Test]
        public void DeveAlterarADataDeVenda()
        {
            var valorEsperado = DateTime.Now;

            var anuncio = new AnuncioBuilder().Build();
            anuncio.AlterarDataDeVenda(valorEsperado);

            Assert.AreEqual(valorEsperado, anuncio.DataDeVenda);
        }

        [Test]
        public void DeveCalcularOLucro()
        {
            var valorDeCompra = 100;
            var valorDeVenda = 250;
            var valorEsperado = 150;

            var anuncio = new AnuncioBuilder().ComValorDeCompra(valorDeCompra).ComValorDeVenda(valorDeVenda).Build();

            Assert.AreEqual(valorEsperado, anuncio.Lucro);
        }
    }
}
