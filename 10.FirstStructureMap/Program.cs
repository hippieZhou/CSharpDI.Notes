using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.FirstStructureMap
{
    class Program
    {
        static void Main(string[] args)
        {
            IContainer container = new Container();
            container.Configure(config => 
            {
                //config.For<IMessage>().Use<ConsoleMessage>();
                config.For<IMessage>().Use<FileMessage>();
                config.For<ILog>().Use<Log>();
            });

            IMessage message = container.GetInstance<IMessage>();
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
