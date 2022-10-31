using AutoMapper;
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
            return Ok(new 
            {
                result = listaAutoresModel,
				httpCode = (int)HttpStatusCode.OK,
				message = "Autores obtidos com sucesso!"
			});
		}

        // GET api/<AutorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AutorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AutorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AutorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
