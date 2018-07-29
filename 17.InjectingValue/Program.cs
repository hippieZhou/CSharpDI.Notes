using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Attributes;
using Unity.Injection;

namespace _17.InjectingValue
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterType<IMessage, ConsoleMessage>(
                new InjectionConstructor("Vulcan", 50),
                new InjectionProperty("Cost", 999.168));

            IMessage message = container.Resolve<IMessage>();
            message.Write("hippieZhou");

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
        public string Name { get; }
        public int Age { get; }
        [Dependency]
        public double Cost { get; set; }
        public ConsoleMessage(string name, int age)
        {
            Name = name;
            Age = age;
        }


        public void Write(string message)
        {
            Console.WriteLine($"Name: {Name}  Age: {Age}");
            Console.WriteLine($"Cost: {Cost}");
            Console.WriteLine($"Message: {message}");
        }
    }
}
