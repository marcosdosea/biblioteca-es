using AutoMapper;
using Core;
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
    public class AutoresController : ControllerBase
    {
        private readonly IAutorService _autorService;
        private readonly IMapper _mapper;

        public AutoresController(IAutorService autorService, IMapper mapper)
        {
            _autorService = autorService;
            _mapper = mapper;
        }

        // GET: api/<AutoresController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaAutores = _autorService.GetAll();
            if (listaAutores == null)
                return NotFound();
            return Ok(listaAutores);
        }

        // GET api/<AutoresController>/5
        [HttpGet("{id}")]
        public ActionResult Get(uint id)
        {
            Autor autor = _autorService.Get(id);
            if (autor == null)
                return NotFound();
            return Ok(autor);
        }

        // POST api/<AutoresController>
        [HttpPost]
        public ActionResult Post([FromBody] AutorViewModel autorModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var autor = _mapper.Map<Autor>(autorModel);
            _autorService.Create(autor);

            return Ok();
        }

        // PUT api/<AutoresController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AutorViewModel autorModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var autor = _mapper.Map<Autor>(autorModel);
            if (autor == null)
                return NotFound();

            _autorService.Edit(autor);

            return Ok();
        }

        // DELETE api/<AutoresController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(uint id)
        {
            Autor autor = _autorService.Get(id);
            if (autor == null)
                return NotFound();

            _autorService.Delete(id);
            return Ok();
        }
    }
}
