using Dominio.Dtos;
using Dominio.Interfaces.Services.Marcas;
using Entidades;
using Microsoft.AspNetCore.Mvc;

namespace AvaliacaoTecnica_EdersonOliveira.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IListarMarcaService _listarMarcasService;
        private readonly IObterMarcaService _obterService;
        private readonly IAdicionarMarcaService _adicionarService;
        private readonly IAlterarMarcaService _alterarService;
        private readonly IDeletarMarcaService _deletarService;

        public MarcaController(IListarMarcaService listarMarcasService,
            IObterMarcaService obterService,
            IAdicionarMarcaService adicionarService,
            IAlterarMarcaService alterarService,
            IDeletarMarcaService deletarService)
        {
            _listarMarcasService = listarMarcasService;
            _obterService = obterService;
            _adicionarService = adicionarService;
            _alterarService = alterarService;
            _deletarService = deletarService;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Get()
        {
            return Ok(_listarMarcasService.Execute());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_obterService.PorId(id));
        }

        [HttpPost]
        public ActionResult Create([FromBody]MarcaDto marcaDto)
        {
            _adicionarService.Execute(marcaDto);

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Update(int id, [FromBody]MarcaDto marcaDto)
        {
            _alterarService.Execute(id, marcaDto);

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            _deletarService.Execute(id);

            return Ok();
        }
    }
}