using AutoMapper;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BibliotecaAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly ILivroService livroService;
        private readonly IAutorService autorService;
        private readonly IEditoraService editoraService;
        private readonly IMapper mapper;

        public LivrosController(ILivroService livroService, IAutorService autorService, IEditoraService editoraService, IMapper mapper)
        {
            this.livroService = livroService;
            this.autorService = autorService;
            this.editoraService = editoraService;
            this.mapper = mapper;
        }

        // GET: api/<LivrosController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaLivros = livroService.GetAll();
            return Ok(listaLivros);
        }

        // GET api/<LivrosController>/5
        [HttpGet("{id}")]
        public ActionResult Get(uint id)
        {
            var livro = livroService.Get(id);
            if (livro == null)
                return NotFound("Livro não encontrado");
            LivroViewModel livroViewModel = mapper.Map<LivroViewModel>(livro);
            return Ok(livroViewModel);
        }

        // POST api/<LivrosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LivrosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LivrosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
