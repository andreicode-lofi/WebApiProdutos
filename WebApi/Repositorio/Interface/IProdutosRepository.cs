using WebApi.Model;

namespace WebApi.Repositorio.Interface
{
    public interface IProdutosRepository
    {
        IEnumerable<Produto> listaProdutos();
        Produto buscarId(int id);
        Produto criar(Produto produto);

        Produto Atualizar(int id, Produto produ);

        Produto Apagar(int id);
    }
}
