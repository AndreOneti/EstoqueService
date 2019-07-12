using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.ServiceModel.Activation;
using EstoqueEntityModel;
using System.Data.Entity;

namespace ServicoEstoqueLibrary
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da classe "Service1" no arquivo de código, svc e configuração ao mesmo tempo.
    // OBSERVAÇÃO: Para iniciar o cliente de teste do WCF para testar esse serviço, selecione Service1.svc ou Service1.svc.cs no Gerenciador de Soluções e inicie a depuração.
    // WCF service that implements the service contract
    // This implementation performs minimal error checking and exception handling
    [AspNetCompatibilityRequirements( RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1 : IService1, IService2
    {
        public bool AdicionarEstoque(string NumeroProduto, int Quantidade)
        {
            try
            {
                // Conectar ao banco
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    // Busca  id para estoque especifico
                    ProdutoEstoque produtoEstoque = (from p in database.ProdutoEstoque
                                     where String.Compare(p.NumeroProduto,NumeroProduto) == 0 select p).First();
                    if (produtoEstoque == null)
                    {
                        return false;
                    }
                    // Busca o estoque
                    produtoEstoque.EstoqueProduto += Quantidade;
                    database.SaveChanges();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public int ConsultaEstoque(string NumeroProduto)
        {
            try
            {
                // Conect ao banco de dados
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    ProdutoEstoque produtoEstoque = (from p in database.ProdutoEstoque
                                                     where String.Compare(p.NumeroProduto, NumeroProduto) == 0
                                                     select p).First();
                    if(produtoEstoque == null)
                    {
                        return 0;
                    }
                    return produtoEstoque.EstoqueProduto;
                }

            }
            catch
            {
                return 0;
            }
        }

        public bool IncluirProduto(Produto Produto)
        {
            try
            {
                // Conect ao banco de dados
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    database.ProdutoEstoque.Add(new ProdutoEstoque() {
                        NumeroProduto = Produto.NumeroProduto,
                        NomeProduto = Produto.NomeProduto,
                        DescricaoProduto = Produto.DescricaoProduto,
                        EstoqueProduto = Produto.EstoqueProduto
                    });
                    database.SaveChanges();
                }

            }
            catch
            {
                return false;
            }
            return true;
        }

        public List<string> ListarProdutos()
        {
            List<string> produtoEstoque = new List<string>();
            try
            {
                // Conectar ao banco
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    // Busca  id para estoque especifico
                    produtoEstoque = (from p in database.ProdutoEstoque select p.NomeProduto).ToList();

                }
            }
            catch
            {
                return produtoEstoque;
            }

            return produtoEstoque;
        }

        public bool RemoverEstoque(string NumeroProduto, int Quantidade)
        {
            try
            {
                // Conectar ao banco
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    // Busca  id para estoque especifico
                    ProdutoEstoque produtoEstoque = (from p in database.ProdutoEstoque
                                                     where String.Compare(p.NumeroProduto, NumeroProduto) == 0
                                                     select p).First();
                    if (produtoEstoque == null)
                    {
                        return false;
                    }
                    // Busca o estoque
                    produtoEstoque.EstoqueProduto -= Quantidade;
                    database.SaveChanges();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool RemoverProduto(string NumeroProduto)
        {
            try
            {
                // Conectar ao banco
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    // Busca  id para estoque especifico
                    ProdutoEstoque produtoEstoque = (from p in database.ProdutoEstoque
                                                     where String.Compare(p.NumeroProduto, NumeroProduto) == 0
                                                     select p).First();
                    if (produtoEstoque == null)
                    {
                        return false;
                    }
                    // Busca o estoque
                    database.ProdutoEstoque.Remove(produtoEstoque);
                    database.SaveChanges();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public Produto VerProduto(string NumeroProduto)
        {
            Produto produto = new Produto();
            try
            {
                // Conectar ao banco
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    // Busca  id para estoque especifico
                    ProdutoEstoque produtoEstoque = (from p in database.ProdutoEstoque
                                                     where String.Compare(p.NumeroProduto, NumeroProduto) == 0
                                                     select p).First();

                    Produto product = new Produto()
                    {
                        NumeroProduto = produtoEstoque.NumeroProduto,
                        NomeProduto = produtoEstoque.NomeProduto,
                        DescricaoProduto = produtoEstoque.DescricaoProduto,
                        EstoqueProduto = produtoEstoque.EstoqueProduto
                    };
                    produto = product;
                }
            }
            catch
            {
                return null;
            }

            return produto;
        }
    }
}
