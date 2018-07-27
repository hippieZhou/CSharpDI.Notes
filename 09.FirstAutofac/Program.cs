using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.FirstAutofac
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            //builder.RegisterType<ConsoleMessage>().As<IMessage>();
            builder.RegisterType<FileMessage>().As<IMessage>();
            builder.RegisterType<Log>().As<ILog>();

            IContainer container = builder.Build();

            IMessage message = container.Resolve<IMessage>();
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
