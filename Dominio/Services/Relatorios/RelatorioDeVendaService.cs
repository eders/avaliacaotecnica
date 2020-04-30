using Dominio.Dtos;
using Dominio.Entidades;
using Dominio.Interfaces.Data;
using Dominio.Interfaces.Services.Relatorios;
using Dominio.Services._Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominio.Services.Relatorios
{
    public class RelatorioDeVendaService : ServiceBase, IRelatorioDeVendaService
    {
        public RelatorioDeVendaService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public List<RelatorioDeVendaDto> Obter(DateTime dataMinima, DateTime dataMaxima)
        {
            return _unitOfWork.Repository<Anuncio>().Query()
               .Where(x => x.DataDeVenda.HasValue
               && (x.DataDeVenda.Value.Date >= dataMinima.Date
               && x.DataDeVenda.Value.Date <= dataMaxima.Date))
                .Select(x => new RelatorioDeVendaDto
                {
                    DataDeVenda = x.DataDeVenda.Value,
                    Lucro = x.Lucro,
                    Veiculo = x.Modelo.Marca.Nome + "(" + x.Modelo.Nome + "" + x.Modelo.Ano+")"
                }).ToList();
        }
    }
}
