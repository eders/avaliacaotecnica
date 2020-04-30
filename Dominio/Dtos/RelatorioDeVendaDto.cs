using System;

namespace Dominio.Dtos
{
    public class RelatorioDeVendaDto
    {
        public DateTime DataDeVenda { get; set; }
        public decimal Lucro { get; set; }
        public string Veiculo { get; set; }
    }
}
