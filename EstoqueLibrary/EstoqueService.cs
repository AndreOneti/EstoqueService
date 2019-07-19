using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using EstoqueEntityModel;
using System.Data.Entity;


namespace EstoqueLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class EstoqueService : IServicoEstoque1, IServicoEstoque2
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
                                                     where String.Compare(p.NumeroProduto, NumeroProduto) == 0
                                                     select p).First();
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
                    if (produtoEstoque == null)
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
                    database.ProdutoEstoque.Add(new ProdutoEstoque()
                    {
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
                    List<ProdutoEstoque> estoques = (from p in database.ProdutoEstoque select p).ToList();

                    foreach (ProdutoEstoque estoque in estoques)
                    {
                        produtoEstoque.Add(estoque.NomeProduto);
                    }
                }
            }
            catch
            {
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
