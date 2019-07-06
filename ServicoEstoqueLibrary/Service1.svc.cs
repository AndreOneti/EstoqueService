using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.ServiceModel.Activation;using EstoqueEntityModel;
using System.Data.Entity;

namespace ServicoEstoqueLibrary
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da classe "Service1" no arquivo de código, svc e configuração ao mesmo tempo.
    // OBSERVAÇÃO: Para iniciar o cliente de teste do WCF para testar esse serviço, selecione Service1.svc ou Service1.svc.cs no Gerenciador de Soluções e inicie a depuração.
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
            throw new NotImplementedException();
        }

        public bool IncluirProduto(Produto Produto)
        {
            throw new NotImplementedException();
        }

        public List<string> ListarProdutos()
        {
            throw new NotImplementedException();
        }

        public bool RemoverEstoque(string NumeroProduto, int Quantidade)
        {
            throw new NotImplementedException();
        }

        public bool RemoverProduto(string NumeroProduto)
        {
            throw new NotImplementedException();
        }

        public Produto VerProduto(string NumeroProduto)
        {
            throw new NotImplementedException();
        }
    }
}
