using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.FirstNinject
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            //kernel.Bind<IMessage>().To<ConsoleMessage>();
            kernel.Bind<IMessage>().To<FileMessage>();
            kernel.Bind<ILog>().To<Log>();

            IMessage message = kernel.Get<IMessage>();
            message.Write("Hello World");

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
            Console.WriteLine($"Message:{message} has wrote on the screen");
        }
    }

    public class FileMessage : IMessage
    {
        private readonly ILog _log;
        public FileMessage(ILog log)
        {
            _log = log;
        }
        public void Write(string message)
        {
            Console.WriteLine($"Message:{message} has wrote on the File");
            _log.Write(message);
        }
    }

    public interface ILog
    {
        void Write(string message);
    }

    public class Log : ILog
    {
        public void Write(string message)
        {
            Console.WriteLine($"Message:{message} has wrote in the Log");
        }
    }
}
