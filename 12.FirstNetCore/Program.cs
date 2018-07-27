using Microsoft.Extensions.DependencyInjection;
using System;

namespace _12.FirstNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection serviceProvider = new ServiceCollection();
            //serviceProvider.AddScoped<IMessage, ConsoleMessage>();
            serviceProvider.AddScoped<IMessage, FileMessage>();
            serviceProvider.AddScoped<ILog, Log>();

            IServiceProvider container = serviceProvider.BuildServiceProvider();
            IMessage message = container.GetService<IMessage>();
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
