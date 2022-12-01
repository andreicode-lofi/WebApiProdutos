using WebApi.Model;

namespace WebApi.Repositorio.Interface
{
    public interface ICategoriasRepository
    {
        IEnumerable<Categoria> ListaCategoria();

        Categoria BuscarId(int id);
        Categoria Criar(Categoria categoria);
        Categoria Atualizar(int id, Categoria categoria);
        Categoria Deletar(int id);
    }
}
