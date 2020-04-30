using Dominio.Entidades;
using NUnit.Framework;
using Testes.Builders;

namespace Testes.Entidades
{
    public class ModeloTestes
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DeveCriarUmModelo()
        {
            var nome = "Civic LXR 2.0";
            var ano = "1998";
            var marcaId = 1;
            
            var modelo = new Modelo(marcaId, nome, ano);

            Assert.AreEqual(nome, modelo.Nome);
            Assert.AreEqual(ano, modelo.Ano);
            Assert.AreEqual(marcaId, modelo.MarcaId);
        }

        [Test]
        public void DeveAlterarOAno()
        {
            var ano = "1998";
           
            var modelo = new ModeloBuilder().Build();
            modelo.AlterarAno(ano);

            Assert.AreEqual(ano, modelo.Ano);
        }

        [Test]
        public void DeveAlterarONome()
        {
            var nome = "Testando";

            var modelo = new ModeloBuilder().Build();
            modelo.AlterarNome(nome);

            Assert.AreEqual(nome, modelo.Nome);
        }

        [Test]
        public void DeveAlterarAMarca()
        {
            var marcaId = 111;

            var modelo = new ModeloBuilder().Build();
            modelo.AlterarMarca(marcaId);

            Assert.AreEqual(marcaId, modelo.MarcaId);
        }
    }
}
