namespace EstoqueEntityModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Criacao_do_Banco : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProdutoEstoques", "NumeroProduto", c => c.String(nullable: false));
            DropColumn("dbo.ProdutoEstoques", "NumeroPoduto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProdutoEstoques", "NumeroPoduto", c => c.String(nullable: false));
            DropColumn("dbo.ProdutoEstoques", "NumeroProduto");
        }
    }
}
