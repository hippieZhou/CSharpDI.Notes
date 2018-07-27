using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ServiceLocatorDependencyInjection.ManualInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            new Client(new MyService()).Start();

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }

    public interface IService
    {
        void Run();
    }
    public class MyService : IService
    {
        public void Run()
        {
            Console.WriteLine("MyService is Running");
        }
    }
    public class Client
    {
        private IService _service;
        public Client(IService service)
        {
            _service = service;
        }
        public void Start()
        {
            Console.WriteLine("My Service is Start");
            _service.Run();
        }
    }
}
