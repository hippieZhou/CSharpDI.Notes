using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ServiceLocatorDependencyInjection.Gouping
{
    class Program
    {
        static void Main(string[] args)
        {
            new Client().Start();

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }

    public class MyService
    {
        public void Run()
        {
            Console.WriteLine("MyService is Running...");
        }
    }

    public class Client
    {
        private MyService _service;
        public Client()
        {
            Console.WriteLine("Create My Service by 'new'");
            _service = new MyService();
        }

        public void Start()
        {
            Console.WriteLine("MyService start");
            _service.Run();
        }
    }
}
