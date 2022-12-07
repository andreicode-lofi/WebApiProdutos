using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Repositorio.Interface;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutosRepository _iprodutoRepository;

        public ProdutoController( IProdutosRepository iprodutoRepository)
        { 
            _iprodutoRepository = iprodutoRepository;
        }

        [HttpGet]//ActionResult altera o retorno para actionResults, se for precisar
        public ActionResult<IEnumerable<Produto>> Get()//IEnumerable Retorna uma lista /  index
        {
            try
            {
                var produtos = _iprodutoRepository.listaProdutos().ToList();
                if (produtos is null)
                {
                    return NotFound("Dados não encontrados...");//ActionResult
                }
                return produtos;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    "Ocorreu um erro ao tratar a sua solicitação...");
            }
        }

        [HttpGet("{id:int}", Name="ObterProduto")]
        public ActionResult<Produto> get(int id)
        {
            try
            {
                var buscarId = _iprodutoRepository.buscarId(id);

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
         public ActionResult Post(Produto produto)
         {
            try
            {
                _iprodutoRepository.criar(produto);

                return new CreatedAtRouteResult("ObterProduto",
                    new { id = produto.ProdutoId }, produto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status410Gone,
                    "Ocorreu um erro ao criar a produto...");
            }  
         }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            try
            {
                if (id != produto.ProdutoId)
                {
                    return BadRequest("Atualização de dados invalida");
                }
                _iprodutoRepository.Atualizar(id, produto);

                return Ok(produto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status304NotModified,
                    $"Ocorreu um erro ao atualiza a produto do id:{id}...");
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var produtos = _iprodutoRepository.Apagar(id);
                return Ok(produtos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status304NotModified,
                    $"Ocorreu um erro ao deletar a produto do id{id}...");
            }
        }
    }
}
