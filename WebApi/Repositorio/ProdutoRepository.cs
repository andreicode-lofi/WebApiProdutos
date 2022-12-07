using WebApi.Context;
using WebApi.Model;
using WebApi.Repositorio.Interface;

namespace WebApi.Repositorio
{
    public class ProdutoRepository : IProdutosRepository
    {
        private readonly appContext _context;

        public ProdutoRepository(appContext context)
        {
            _context = context;
        }

        public Produto Apagar(int id)
        {
            var produto = buscarId(id);

            if(produto is null)
            {
                return null;
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return produto;
        }

        public Produto Atualizar(int id, Produto produto)
        {
            //Entry() metodo para modificar o estatado do objeto produto
            _context.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();         // aqui definindo estado do objeto
            return produto;
        }

        public Produto buscarId(int id)
        {
            return _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
        }

        public Produto criar(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return produto;
        }

        public IEnumerable<Produto> listaProdutos()
        {
            return _context.Produtos.Take(10).ToList();
            //retornando apenas os 10 primeiros registros,
            //retornar a entidade completa pode causar sobre carga
        }
    }
}
