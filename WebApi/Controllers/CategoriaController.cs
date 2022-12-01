using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Repositorio.Interface;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriasRepository _icategoriasRepository;
        public CategoriaController(ICategoriasRepository icategoriasRepository)
        {
            _icategoriasRepository = icategoriasRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            var listaCategoria = _icategoriasRepository.ListaCategoria().ToList();

            if (listaCategoria == null)
            {
                return NotFound("Lista não encontrada...");
            }

            return listaCategoria;
        }

        [HttpGet("{id:int}", Name ="ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            var buscarId = _icategoriasRepository.BuscarId(id);

            if(buscarId == null)
            {
                return NotFound("Categoria não encontrada...");
            }

            return buscarId;
        }

        [HttpPost]
        public ActionResult<Categoria> Post(Categoria categoria)
        {
            if(categoria == null)
            {
                return BadRequest();
            }

            var addCategoria = _icategoriasRepository.Criar(categoria);

            return new CreatedAtRouteResult("ObterCategoria",
                 new { id = categoria.CategoriaId }, categoria);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            if(id != categoria.CategoriaId)
            {
                return BadRequest();
            }

            _icategoriasRepository.Atualizar(id, categoria);

            return Ok(categoria);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Categoria> Delete(int id)
        {
            var produto = _icategoriasRepository.Deletar(id);
            return Ok(produto);
        }

    }
}
