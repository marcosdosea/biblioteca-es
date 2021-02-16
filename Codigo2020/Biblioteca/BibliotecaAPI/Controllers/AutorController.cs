using AutoMapper;
using Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
		public ActionResult<List<AutorModel>> Get()
		{
			var listaAutores = _autorService.ObterTodos();
			var listaAutoresModel = _mapper.Map<List<AutorModel>>(listaAutores);

			return listaAutoresModel;
		}

		// GET api/<AutorController>/5
		[HttpGet("{id}")]
		public ActionResult<AutorModel> Get(int id)
		{
			Autor autor = _autorService.Obter(id);
			AutorModel autorModel = _mapper.Map<AutorModel>(autor);
			return autorModel;
		}

		// POST api/<AutorController>
		[HttpPost]
		public void Post([FromBody] AutorModel autorModel)
		{
			if (ModelState.IsValid)
			{
				var autor = _mapper.Map<Autor>(autorModel);
				_autorService.Inserir(autor);
			}
		}

		// PUT api/<AutorController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] AutorModel autorModel)
		{
			if (ModelState.IsValid)
			{
				var autor = _mapper.Map<Autor>(autorModel);
				autor.IdAutor = id;
				_autorService.Editar(autor);
			}
		}

		// DELETE api/<AutorController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			_autorService.Remover(id);
		}
	}
}
