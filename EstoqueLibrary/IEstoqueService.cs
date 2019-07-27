using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EstoqueLibrary
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da interface "IService1" no arquivo de código e configuração ao mesmo tempo.
    [ServiceContract(Namespace = "http://projetoavaliativo.dm113/01", Name = "IServicoEstoque1")]
    public interface IServicoEstoque1
    {

        // Get all products
        [OperationContract]
        List<string> ListarProdutos();

        // Insert products
        [OperationContract]
        bool IncluirProduto(Produto Produto);

        // Remove products
        [OperationContract]
        bool RemoverProduto(string NumeroProduto);

        // Consult stock
        [OperationContract]
        int ConsultaEstoque(string NumeroProduto);

        // Add stock
        [OperationContract]
        bool AdicionarEstoque(string NumeroProduto, int Quantidade);

        // Remove stock
        [OperationContract]
        bool RemoverEstoque(string NumeroProduto, int Quantidade);

        // See Product
        [OperationContract]
        Produto VerProduto(string NumeroProduto);

    }

    [ServiceContract(Namespace = "http://projetoavaliativo.dm113/02", Name = "IServicoEstoque2")]
    public interface IServicoEstoque2
    {

        // Add stock
        [OperationContract]
        bool AdicionarEstoque(string NumeroProduto, int Quantidade);

        // Remove stock
        [OperationContract]
        bool RemoverEstoque(string NumeroProduto, int Quantidade);

        // Consult stock
        [OperationContract]
        int ConsultaEstoque(string NumeroProduto);

    }


    // Use um contrato de dados como ilustrado no exemplo abaixo para adicionar tipos compostos a operações de serviço.
    [DataContract]
    public class Produto
    {
        [DataMember]
        public string NumeroProduto { get; set; }

        [DataMember]
        public string NomeProduto { get; set; }

        [DataMember]
        public string DescricaoProduto { get; set; }

        [DataMember]
        public int EstoqueProduto { get; set; }

    }
}
