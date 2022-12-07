using Microsoft.EntityFrameworkCore;
using WebApi.Context;
using WebApi.Model;
using WebApi.Repositorio.Interface;

namespace WebApi.Repositorio
{
    public class CategoriasRepository : ICategoriasRepository
    {

        private readonly appContext _context;

        public CategoriasRepository(appContext context)
        {
            _context = context;
        }

        public Categoria Atualizar(int id, Categoria categoria)
        {
            //Entry() metodo para modificar o estatado do objeto 
            _context.Entry(categoria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();         // aqui definindo o estado do objeto
            return categoria;
        }

        public Categoria BuscarId(int id)
        {
            return _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);
        }

        public Categoria Criar(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return categoria;
        }

        public Categoria Deletar(int id)
        {
            var categoriaDb = BuscarId(id);

            _context.Remove(categoriaDb);
            _context.SaveChanges();
            return categoriaDb;
        }

        public IEnumerable<Categoria> ListaCategoria()
        {
            return _context.Categorias.Take(10).ToList();
            //retornando apenas os 10 primeiros registros,
            //retornar a entidade completa pode causar sobre carga
        }

        public IEnumerable<Categoria> ListaCategoriaProduto()
        {
            return _context.Categorias.Include(c => c.Produtos).ToList();
            
        }
    }
}
