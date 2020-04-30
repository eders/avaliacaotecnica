using Dominio.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces.Services.Relatorios
{
    public interface IRelatorioDeVendaService 
    {
        List<RelatorioDeVendaDto> Obter(DateTime dataMinima, DateTime dataMaxima);
    }
}
