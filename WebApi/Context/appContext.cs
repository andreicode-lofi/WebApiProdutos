using Microsoft.EntityFrameworkCore;
using WebApi.Model;

namespace WebApi.Context
{
    public class appContext : DbContext
    {
        public appContext(DbContextOptions<appContext>options) : base(options)
        {

        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}
