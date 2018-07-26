using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversion
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public interface IMessage
    {
        void Send();
    }

    public class Email : IMessage
    {
        public void Send()
        {
            throw new NotImplementedException();
        }
    }

    public class Notification
    {
        private readonly IMessage _message;

        public Notification(IMessage message)
        {
            _message = message;
        }

        public void Notify()
        {
            _message.Send();
        }
    }
}
