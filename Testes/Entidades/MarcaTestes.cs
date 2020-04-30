using Entidades;
using NUnit.Framework;


namespace Testes.Entidades
{
    public class MarcaTestes
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DeveCriarUmaMarca()
        {
            var nome = "Honda";

            var marca = new Marca(nome);

            Assert.AreEqual(nome , marca.Nome );
        }

        [Test]
        public void DeveAlterarAMarca()
        {
            var nomeAntigo = "Honda";
            var nomeNovo = "Fiat";

            var marca = new Marca(nomeAntigo);
            marca.AlterarNome(nomeNovo);

            Assert.AreEqual(nomeNovo, marca.Nome);
        }
    }
}