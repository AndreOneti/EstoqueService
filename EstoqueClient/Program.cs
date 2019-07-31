using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using EstoqueClient.EstoqueService;

namespace EstoqueClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicoEstoque1Client proxy = new ServicoEstoque1Client("BasicHttpBinding_IServicoEstoque1");

            // Test the operations in the service
            // Obtain a list of all products
            Console.WriteLine("Test 1: List all products");
            List<string> products = proxy.ListarProdutos().ToList();
            foreach (string p in products)
            {
                Console.WriteLine("Name: {0}", p);
                Console.WriteLine();
            }
            Console.WriteLine();

            // Get details of this product
            Console.WriteLine("Test 2: Display the details of a product");
            Produto product = proxy.VerProduto("10000");
            Console.WriteLine("Name: {0}", product.NomeProduto);
            Console.WriteLine("Code: {0}", product.NumeroProduto);
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
