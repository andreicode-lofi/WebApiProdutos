using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class migrationPopula2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,UrlImagen,Estoque,DataCadastro,CategoriaId)"
                + "Values('Coca-Cola Deit','Refrigerante de cola 350ml',4.50,'cocacola.jpg',50,getdate(),1)");

            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,UrlImagen,Estoque,DataCadastro,CategoriaId)"
                + "Values('X salada','pão queijo presunto hambúrguer e salada',6.50,'xsalada.jpg',50,getdate(),2)");

            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,UrlImagen,Estoque,DataCadastro,CategoriaId)"
                + "Values ('Pudim 100g','Pudin de leite condensado 100g',6.70,'pudim.jpg',50,getdate(),3)");

            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,UrlImagen,Estoque,DataCadastro,CategoriaId)"
                + "Values ('Hot dog','pao salsicha molho e batata palha',4.50,'hotdog.jpg',50,getdate(),2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Produtos");
        }
    }
}
