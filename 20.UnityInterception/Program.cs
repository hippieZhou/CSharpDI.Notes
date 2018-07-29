using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Interception.PolicyInjection.Pipeline;

namespace _20.UnityInterception
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();

            var fooInterception = new Interception();
            container.AddExtension(fooInterception);

            container.RegisterType<IMessage, ConsoleMessage>(
                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<AppLog>(),
                new InterceptionBehavior<VirtualLog>());

            IMessage message = container.Resolve<IMessage>();
            Console.WriteLine($"{Environment.NewLine} Call IMessage.Write");
            message.Write("Hi Vulcan");
            Console.WriteLine($"{Environment.NewLine} Call IMessage.Empty");
            message.Empty();

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }
    public interface IMessage
    {
        void Write(string message);
        void Empty();
    }

    public class ConsoleMessage : IMessage
    {
        public void Write(string message)
        {
            Console.WriteLine($"Message: {message} ");
        }
        public void Empty()
        {
            Console.WriteLine($"this is a Empty Function");
        }
    }

    public class AppLog : IInterceptionBehavior
    {
        public bool WillExecute => true;

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            IMethodReturn result = null;
            if (input.MethodBase.Name == "Write")
            {
                Console.WriteLine($"(AppLog) Before：{input.MethodBase.DeclaringType.Name}.{input.MethodBase.Name}");
                result = getNext()(input, getNext);
                Console.WriteLine($"(AppLog) After：{input.MethodBase.DeclaringType.Name}{input.MethodBase.Name}");
                return result;
            }
            return getNext()(input, getNext);
        }
    }

    public class VirtualLog : IInterceptionBehavior
    {
        public bool WillExecute => true;

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            IMethodReturn result = null;
            if (input.MethodBase.Name == "Empty")
            {
                Console.WriteLine($"(VirtualLog) Before：{input.MethodBase.DeclaringType.Name}.{input.MethodBase.Name}");
                result = getNext()(input, getNext);
                Console.WriteLine($"(VirtualLog) After：{input.MethodBase.DeclaringType.Name}{input.MethodBase.Name}");
                return result;
            }
            return getNext()(input, getNext);
        }
    }
}
