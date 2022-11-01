using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {

		private readonly IAutorService _autorService;
		private readonly IMapper _mapper;

		public AutorController(IAutorService autorService, IMapper mapper)
		{
			_autorService = autorService;
			_mapper = mapper;
		}

        // GET: api/<AutorController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaAutores = _autorService.GetAll();
			var listaAutoresModel = _mapper.Map<List<AutorModel>>(listaAutores);
			return Ok(listaAutoresModel);
		}

        // GET api/<AutorController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
			Autor autor = _autorService.Get(id);
            if (autor == null)
                return NotFound();
            return Ok(autor);
		}

        // POST api/<AutorController>
        [HttpPost]
        public ActionResult Post([FromBody] AutorModel autorModel)
        {
			if (!ModelState.IsValid)
				return BadRequest("Dados inválidos.");

			var autor = _mapper.Map<Autor>(autorModel);
			_autorService.Create(autor);
			
            return Ok();
		}

        // PUT api/<AutorController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AutorModel autorModel)
        {
			if (!ModelState.IsValid)
				return BadRequest("Dados inválidos.");

			var autor = _mapper.Map<Autor>(autorModel);
			if (autor == null)
				return NotFound();
            
            _autorService.Edit(autor);
			
			return Ok();
		}

        // DELETE api/<AutorController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
			Autor autor = _autorService.Get(id);
			if (autor == null)
				return NotFound();
			
		    _autorService.Delete(id);
			return Ok();
		}
    }
}
