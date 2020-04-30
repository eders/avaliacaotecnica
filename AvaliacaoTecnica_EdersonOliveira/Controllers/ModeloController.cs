using Dominio.Dtos;
using Dominio.Interfaces.Services.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace AvaliacaoTecnica_EdersonOliveira.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloController : ControllerBase
    {

        private readonly IListarModelosService _listarModelosService;
        private readonly IObterModeloService _obterService;
        private readonly IAdicionarModeloService _adicionarService;
        private readonly IAlterarModeloService _alterarService;
        private readonly IDeletarModeloService _deletarService;

        public ModeloController(IListarModelosService listarModelosService,
              IObterModeloService obterService,
            IAdicionarModeloService adicionarService,
            IAlterarModeloService alterarService,
            IDeletarModeloService deletarService)
        {
            _listarModelosService = listarModelosService;
            _obterService = obterService;
            _adicionarService = adicionarService;
            _alterarService = alterarService;
            _deletarService = deletarService;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Get()
        {
            return Ok(_listarModelosService.Execute());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_obterService.PorId(id));
        }

        [HttpGet]
        [Route("marca/{marcaId}")]
        public ActionResult GetModelosPorMarca(int marcaId)
        {
            return Ok(_obterService.PorMarca(marcaId));
        }

        [HttpPost]
        public ActionResult Create([FromBody]ModeloDto modeloDto)
        {
            _adicionarService.Execute(modeloDto);

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Update(int id, [FromBody]ModeloDto modeloDto)
        {
            _alterarService.Execute(id, modeloDto);

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