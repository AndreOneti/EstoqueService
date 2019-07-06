namespace EstoqueEntityModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ajuste_do_Banco : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProdutoEstoques", "NomeProduto", c => c.String(nullable: false));
            DropColumn("dbo.ProdutoEstoques", "NomePoduto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProdutoEstoques", "NomePoduto", c => c.String(nullable: false));
            DropColumn("dbo.ProdutoEstoques", "NomeProduto");
        }
    }
}
