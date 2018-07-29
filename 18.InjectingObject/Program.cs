using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace _18.InjectingObject
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();

            IMessage message = new ConsoleMessage();
            container.RegisterInstance(message);

            IMessage message1 = container.Resolve<IMessage>();
            IMessage message2 = container.Resolve<IMessage>();
            IMessage message3 = container.Resolve<IMessage>();
            message1.Write("1");
            message2.Write("2");
            message3.Write("3");

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
            Console.WriteLine($"this Object HashCode {this.GetHashCode()},{message}");
        }
    }
}
