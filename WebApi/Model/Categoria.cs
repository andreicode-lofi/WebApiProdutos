using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
namespace WebApi.Model
{
    public class Categoria
    {
        
        public Categoria()
        {
            //inicializando a minha propriedade de coleção 
            //porque é responsabilidade da class que esta a coleção,
            //inicial a coleção 
            Produtos = new Collection<Produto>();
        }

        [Key]
        public int CategoriaId { get; set; }

        [Required]
        [MaxLength(80)]
        public string? Nome { get; set; }

        [Required]
        [MaxLength(300)]
        public string? UrlImagem { get; set; }

        public ICollection<Produto>? Produtos { get; set; }
    }
}
