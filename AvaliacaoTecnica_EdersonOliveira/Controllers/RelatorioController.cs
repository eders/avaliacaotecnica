using Dominio.Interfaces.Services.Relatorios;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AvaliacaoTecnica_EdersonOliveira.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly IRelatorioDeVendaService _relatorioDeVendaService;
        public RelatorioController(IRelatorioDeVendaService relatorioDeVendaService)
        {
            _relatorioDeVendaService = relatorioDeVendaService;
        }

        [HttpGet]
        [Route("venda")]
        public ActionResult Get(DateTime dataMinima, DateTime dataMaxima)
        {
            return Ok(_relatorioDeVendaService.Obter(dataMinima, dataMaxima));
        }
    }
}