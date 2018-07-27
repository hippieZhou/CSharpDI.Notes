using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.InversionOfControlOO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DependencyService:");
            DependencyService();

            Console.WriteLine();

            Console.WriteLine("InversionDependencyService:");
            InversionDependencyService();

            Console.ReadKey();
        }

        static void DependencyService()
        {
            EmailService fooEmailService = new EmailService();
            fooEmailService.Send();
        }
        static void InversionDependencyService()
        {
            IMessage fooMessage = Factory.GetEmailService();
            fooMessage.Send();
            fooMessage = Factory.GetSMSService();
            fooMessage.Send();
        }
    }

    public interface IMessage
    {
        void Send();
    }

    public class EmailService : IMessage
    {
        public void Send()
        {
            Console.WriteLine("EmailService Send Message");
        }
    }

    public class SMSService : IMessage
    {
        public void Send()
        {
            Console.WriteLine("SMSService Send Message");
        }
    }

    public static class Factory
    {
        public static EmailService GetEmailService() => new EmailService();

        public static SMSService GetSMSService() => new SMSService();
    }
}
