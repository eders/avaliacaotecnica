using Bogus;
using Dominio.Entidades;

namespace Testes.Builders
{
    public class ModeloBuilder
    {
        private Modelo _modelo;

        public ModeloBuilder()
        {
            _modelo = new Modelo(1,"teste","0000");
        }

        public Modelo Build() => _modelo;
    }
}
