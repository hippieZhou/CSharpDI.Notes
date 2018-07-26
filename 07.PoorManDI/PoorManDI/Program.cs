using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoorManDI
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDI.Register<IMessage, FileMessage>();
            SendMessage("Hello World");

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }

        private static void SendMessage(string message)
        {
            var fooIMessage = MyDI.Resolve<IMessage>();
            fooIMessage.Write(message);
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
            Console.WriteLine($"The {message} is display on screen");
        }
    }
    public class FileMessage : IMessage
    {
        public void Write(string message)
        {
            Console.WriteLine($"The {message} is write on file");
        }
    }

    public static class MyDI
    {
        static readonly Dictionary<Type, Type> Maps = new Dictionary<Type, Type>();

        public static void Register<TAbstractType, TConcreteType>()
        {
            Maps[typeof(TAbstractType)] = typeof(TConcreteType);
        }

        public static TAbstractType Resolve<TAbstractType>()
        {
            Type fooConcreteType = Maps[typeof(TAbstractType)];
            object instance = Activator.CreateInstance(fooConcreteType);
            return (TAbstractType)instance;
        }
    }
}
