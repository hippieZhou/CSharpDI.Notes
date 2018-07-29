using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace _23.UnityConfigurationXML
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer().LoadConfiguration();

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
        public void Write(string message)
        {
            Console.WriteLine($"This Object HashCode {this.GetHashCode()}");
        }
    }
}
