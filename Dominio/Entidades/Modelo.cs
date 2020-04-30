using Entidades;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Modelo
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Ano { get; private set; }
        public int MarcaId { get; private set; }
        public virtual Marca Marca { get; private set; }
        protected Modelo() { }

        public Modelo(int marcaId, string nome, string ano)
        {
            MarcaId = marcaId;
            Nome = nome;
            Ano = ano;
        }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }

        public void AlterarAno(string ano)
        {
            Ano = ano;
        }

        public void AlterarMarca(int marcaId)
        {
            MarcaId = marcaId;
        }
    }
}
