using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;

namespace _16.MultiConstructor
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterType<IDependency1, Dependency1>();
            container.RegisterType<IDependency2, Dependency2>();
            container.RegisterType<IDependency3, Dependency3>();
            container.RegisterType<IDependency4, Dependency4>();

            container.RegisterType<IInfrastructure, Infrastructure>();
            container.Resolve<IInfrastructure>();

            container.RegisterType<IInfrastructure, Infrastructure>(new InjectionConstructor
                (new ResolvedParameter<IDependency1>(), new ResolvedParameter<IDependency2>()));
            container.Resolve<IInfrastructure>();

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }

    interface IDependency1 { }
    class Dependency1 : IDependency1 { }
    interface IDependency2 { }
    class Dependency2 : IDependency2 { }
    interface IDependency3 { }
    class Dependency3 : IDependency3 { }
    interface IDependency4 { }
    class Dependency4 : IDependency4 { }
    interface IInfrastructure
    {
    }

    class Infrastructure : IInfrastructure
    {
        public Infrastructure(IDependency1 d1)
        { Console.WriteLine("one"); }
        public Infrastructure(IDependency1 d1, IDependency2 d2)
        { Console.WriteLine("two"); }
        public Infrastructure(IDependency1 d1, IDependency2 d2,
            IDependency3 d3)
        { Console.WriteLine("three"); }
        public Infrastructure(IDependency1 d1, IDependency2 d2,
            IDependency3 d3, IDependency4 d4)
        { Console.WriteLine("four"); }
    }
}
