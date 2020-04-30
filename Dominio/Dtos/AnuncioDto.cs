using Dominio.Enumeradores;
using System;

namespace Dominio.Dtos
{
    public class AnuncioDto
    {
        public int Id { get; set; }
        public decimal ValorDeCompra { get; set; }
        public decimal ValorDeVenda { get; set; }
        public ECor Cor { get; set; }
        public ETipoDeCombustivel TipoDeCombustivel { get; set; }
        public DateTime? DataDeVenda { get; set; }
        public int ModeloId { get; set; }
        public int MarcaId { get; set; }
        public string NomeModelo { get; set; }
        public string NomeMarca { get; set; }

        public bool Vendido
        {
            get
            {
                return DataDeVenda != null;
            }
        }
    }
}
