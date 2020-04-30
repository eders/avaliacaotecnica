

using Dominio.Entidades;
using System.Collections.Generic;

namespace Entidades
{
    public class Marca
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }

        public virtual List<Modelo> Modelos { get; private set; }

        protected Marca() { }
        public Marca(string nome)
        {
            Nome = nome;
        }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }
    }
}