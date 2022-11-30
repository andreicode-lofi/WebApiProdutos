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

        [HttpGet] //ActionResult altera o retorno para actionResults, se for precisar
        public ActionResult<IEnumerable<Produto>> Get()//IEnumerable Retorna uma lista /  index
        {
            var produtos = _iprodutoRepository.listaProdutos().ToList();
            if(produtos is null)
            {
                return NotFound("Produtos não encontrados...");//ActionResult
            }
            return produtos;
        }

        [HttpGet("{id:int}", Name="ObterProduto")]
        public ActionResult<Produto> get(int id)
        {
            var buscarId = _iprodutoRepository.buscarId(id);
            
            if(buscarId == null)
            {
                return NotFound("Produto não encontrado");
            }
            return buscarId;
        }

         [HttpPost]
         public ActionResult Post(Produto produto)
         {
            _iprodutoRepository.criar(produto);
            
             return new CreatedAtRouteResult("ObterProduto", 
                 new {id = produto.ProdutoId}, produto);
         }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            if(id != produto.ProdutoId)
            {
                return BadRequest();
            }
            _iprodutoRepository.Atualizar(id,produto);

            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produtos = _iprodutoRepository.Apagar(id);
            return Ok(produtos);
        }
    }
}
