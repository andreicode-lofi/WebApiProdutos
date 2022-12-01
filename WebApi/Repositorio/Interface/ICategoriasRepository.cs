using WebApi.Model;

namespace WebApi.Repositorio.Interface
{
    public interface ICategoriasRepository
    {
        IEnumerable<Categoria> ListaCategoria();

        IEnumerable<Categoria> ListaCategoriaProduto();

        Categoria BuscarId(int id);
        Categoria Criar(Categoria categoria);
        Categoria Atualizar(int id, Categoria categoria);
        Categoria Deletar(int id);
    }
}
