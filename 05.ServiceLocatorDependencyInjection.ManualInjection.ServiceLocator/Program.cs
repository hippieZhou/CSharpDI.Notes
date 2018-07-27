using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ServiceLocatorDependencyInjection.ManualInjection.ServiceLocator
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

    public interface IService
    {
        void Run();
    }

    public class MyService : IService
    {
        public void Run()
        {
            Console.WriteLine("My Service is running");
        }
    }

    public class Client
    {
        private readonly IService _service;
        public Client()
        {
            _service = LocateService.GetService<IService>();
        }
        public void Start()
        {
            Console.WriteLine("MyService is Start");
            _service?.Run();
        }
    }

    public static class LocateService
    {
        public static Dictionary<object, object> servicecontainer = null;
        public static IService Service { get; set; }

        static LocateService()
        {
            Console.WriteLine("init LocateService");
            servicecontainer = new Dictionary<object, object>
            {
                { typeof(IService), new MyService() }
            };
        }

        public static T GetService<T>()
        {
            try
            {
                return (T)servicecontainer[typeof(T)];
            }
            catch (Exception)
            {
                throw new NotImplementedException("Service isn't exist");
            }
        }
    }
}
