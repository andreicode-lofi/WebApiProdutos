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

        [HttpGet("ObterProduto")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
        {
            return _icategoriasRepository.ListaCategoriaProduto().ToList();
            
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            try
            {
                var listaCategoria = _icategoriasRepository.ListaCategoria().ToList();

                if (listaCategoria == null)
                {
                    return NotFound("Dados não encontrado...");
                }

                return listaCategoria;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    "Ocorreu um erro ao tratar a sua solicitação...");
            }
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            try
            {
                var buscarId = _icategoriasRepository.BuscarId(id);

                if (buscarId == null)
                {
                    return NotFound($"O id:{id} não existe");
                }

                return buscarId;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status400BadRequest,
                    $"Ocorreu um erro ao tratar a sua solicitação do id {id}...");
            }
        }

        [HttpPost]
        public ActionResult<Categoria> Post(Categoria categoria)
        {
            try
            {
                if (categoria is null)
                {
                    return BadRequest("Categoria invalida");
                }

                _icategoriasRepository.Criar(categoria);

                return new CreatedAtRouteResult("ObterCategoria",
                     new { id = categoria.CategoriaId }, categoria);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status410Gone,
                    "Ocorreu um erro ao criar a categoria...");
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            try
            {
                if (id != categoria.CategoriaId)
                {
                    return BadRequest("Atualização de dados invalida");
                }

                _icategoriasRepository.Atualizar(id, categoria);

                return Ok(categoria);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status304NotModified,
                    $"Ocorreu um erro ao atualiza a categoria do id:{id}...");
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Categoria> Delete(int id)
        {
            try
            {
                var produto = _icategoriasRepository.Deletar(id);
                return Ok(produto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status304NotModified,
                    $"Ocorreu um erro ao deletar a categoria do id{id}...");
            }
        }
    }
}
