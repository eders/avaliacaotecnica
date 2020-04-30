using Dominio.Dtos;
using Dominio.Interfaces.Services.Anuncios;
using Microsoft.AspNetCore.Mvc;

namespace AvaliacaoTecnica_EdersonOliveira.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnuncioController : ControllerBase
    {
        private readonly IListarAnuncioService _listarAnuncioService;
        private readonly IObterAnuncioService _obterAnuncioService;
        private readonly IAdicionarAnuncioService _adicionarAnuncioService;
        private readonly IAlterarAnuncioService _alterarAnuncioService;
        private readonly IDeletarAnuncioService _deletarAnuncioService;
        public AnuncioController(IListarAnuncioService listarAnuncioService,
            IObterAnuncioService obterAnuncioService,
            IAdicionarAnuncioService adicionarAnuncioService,
            IAlterarAnuncioService alterarAnuncioService,
            IDeletarAnuncioService deletarAnuncioService)
        {
            _listarAnuncioService = listarAnuncioService;
            _obterAnuncioService = obterAnuncioService;
            _adicionarAnuncioService = adicionarAnuncioService;
            _alterarAnuncioService = alterarAnuncioService;
            _deletarAnuncioService = deletarAnuncioService;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Get()
        {
            return Ok(_listarAnuncioService.Execute());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_obterAnuncioService.PorId(id));
        }

        [HttpPost]
        public ActionResult Create([FromBody]AnuncioDto anuncio)
        {
            _adicionarAnuncioService.Execute(anuncio);

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Update(int id, [FromBody]AnuncioDto anuncio)
        {
            _alterarAnuncioService.Execute(id, anuncio);

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            _deletarAnuncioService.Execute(id);

            return Ok();
        }
    }
}