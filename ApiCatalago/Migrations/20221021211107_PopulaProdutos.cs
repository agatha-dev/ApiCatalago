using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalago.Migrations
{
    public partial class PopulaProdutos : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId)" +
           "Values('Coca-Cola Diet','Refrigerante de Cola 350 ml',5.45,'cocacola.jpg',50,'18-06-12 10:34:09 PM',1)");


            //mb.Sql("Insert into Produtos(ProdutoId,Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId)" +
            //     "Values(2,'Lanche de Atum','Lanche de Atum com maionese',8.50,'atum.jpg',10,'18-06-12 10:34:09 PM',2)");



            //mb.Sql("Insert into Produtos(ProdutoId,Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId)" +
            //    "Values(3,'Pudim 100 g','Pudim de leite condensado 100g',6.75,'pudim.jpg',20,'18-06-12 10:34:09 PM',3)");

        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Produtos");
        }
    }
}
