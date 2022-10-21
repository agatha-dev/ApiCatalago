using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalago.Migrations
{
    public partial class ContinuaPopuolarProdutos : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId)" +
           "Values('Sorvete','Napolitano 5 litros',15.45,'sorvete.jpg',50,'18-06-12 10:34:09 PM',3)");

            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId)" +
          "Values('XTUDO','XTUDO COMPLETO',10.45,'Xtudo.jpg',50,'18-06-12 10:34:09 PM',2)");

        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Produtos");
        }
    }
}
