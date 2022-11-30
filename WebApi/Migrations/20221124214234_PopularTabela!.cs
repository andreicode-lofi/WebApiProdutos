using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class PopularTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Categorias(Nome, UrlImagem) Values('Bebidas', 'bebidas.jpg')");
            mb.Sql("Insert into Categorias(Nome, UrlImagem) Values('Lanches', 'Lanches.jpg')");
            mb.Sql("Insert into Categorias(Nome, UrlImagem) Values('Sobremesas', 'Sobremesas.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Categorias");
           

        }
    }
}
