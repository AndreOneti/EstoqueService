using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using EstoqueLibrary;

namespace ProvedorEstoqueHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost ProdutoEstoquesServiceHost = new ServiceHost(typeof(EstoqueService));
            ProdutoEstoquesServiceHost.Open();
            Console.WriteLine("Service Running");
            Console.ReadLine();
            Console.WriteLine("Service Stopping");
            ProdutoEstoquesServiceHost.Close();
        }
    }
}
