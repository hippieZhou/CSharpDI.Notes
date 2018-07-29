using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace _15.RegisterTypeNamed
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterType<IMessage, ConsoleMessage>("Console");
            container.RegisterType<IMessage, FileMessage>();

            IMessage message1 = container.Resolve<IMessage>();
            message1.Write("Hello World");

            IMessage message2 = container.Resolve<IMessage>("Console");
            message2.Write("Hello World");

            Console.WriteLine();
            foreach (var item in container.Registrations)
            {
                Console.WriteLine($"Name : {item.Name}");
                Console.WriteLine($"RegisteredType : {item.RegisteredType.Name}");
                Console.WriteLine($"MappedToType : {item.MappedToType.Name}");
                Console.WriteLine($"LifetimeManager : {item.LifetimeManager.LifetimeType.Name}");
                Console.WriteLine();
            }

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }
    public interface IMessage
    {
        void Write(string message);
    }

    public class ConsoleMessage : IMessage
    {
        public void Write(string message)
        {
            Console.WriteLine($"ConsoleMessage: {message} ");
        }
    }

    public class FileMessage : IMessage
    {
        public void Write(string message)
        {
            Console.WriteLine($"FileMessage: {message} ");
        }
    }
}
