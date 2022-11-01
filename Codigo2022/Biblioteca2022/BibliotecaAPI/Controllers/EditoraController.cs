using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BibliotecaAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EditoraController : ControllerBase
	{

		private readonly IEditoraService _editoraService;
		private readonly IMapper _mapper;

		public EditoraController(IEditoraService editoraService, IMapper mapper)
		{
			_editoraService = editoraService;
			_mapper = mapper;
		}

		// GET: api/<EditoraController>
		[HttpGet]
		public ActionResult Get()
		{
			var listaEditoras = _editoraService.GetAll();
			var listaEditorasModel = _mapper.Map<List<EditoraModel>>(listaEditoras);
			return Ok(listaEditorasModel);
		}

		// GET api/<EditoraController>/5
		[HttpGet("{id}")]
		public ActionResult Get(int id)
		{
			Editora editora = _editoraService.Get(id);
			if (editora == null)
				return NotFound();
			return Ok(editora);
		}

		// POST api/<EditoraController>
		[HttpPost]
		public ActionResult Post([FromBody] EditoraModel editoraModel)
		{
			if (!ModelState.IsValid)
				return BadRequest("Dados inválidos.");

			var editora = _mapper.Map<Editora>(editoraModel);
			_editoraService.Create(editora);

			return Ok();
		}

		// PUT api/<EditoraController>/5
		[HttpPut("{id}")]
		public ActionResult Put(int id, [FromBody] EditoraModel editoraModel)
		{
			if (!ModelState.IsValid)
				return BadRequest("Dados inválidos.");

			var editora = _mapper.Map<Editora>(editoraModel);
			if (editora == null)
				return NotFound();

			_editoraService.Edit(editora);

			return Ok();
		}

		// DELETE api/<EditoraController>/5
		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			Editora editora = _editoraService.Get(id);
			if (editora == null)
				return NotFound();

			_editoraService.Delete(id);
			return Ok();
		}
	}
}
