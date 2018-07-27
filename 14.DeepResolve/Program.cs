using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace _14.DeepResolve
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

            var foo = container.Resolve<ViewModel>();
            Console.WriteLine($"ViewModel:{foo.GetHashCode()}");

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }

    public interface IDependency1 { }
    public class Dependency1 : IDependency1 { }
    public interface IDependency2 { }
    public class Dependency2 : IDependency2 { }

    public interface IDependency3 { }
    public class Dependency3 : IDependency3 { }

    public interface IDependency4 { }
    public class Dependency4 : IDependency4 { }

    public interface IInfrastructure
    {
        string Name { get; set; }
    }

    class Infrastructure : IInfrastructure
    {
        public string Name { get; set; }

        IDependency1 D1;
        IDependency2 D2;
        IDependency3 D3;
        IDependency4 D4;
        public Infrastructure(IDependency1 d1, IDependency2 d2, IDependency3 d3, IDependency4 d4)
        {
            D1 = d1;
            D2 = d2;
            D3 = d3;
            D4 = d4;

            Console.WriteLine($"Dependency1 : {D1.GetHashCode()}");
            Console.WriteLine($"Dependency2 : {D2.GetHashCode()}");
            Console.WriteLine($"Dependency3 : {D3.GetHashCode()}");
            Console.WriteLine($"Dependency4 : {D4.GetHashCode()}");
        }

    }

    class ViewModel
    {
        private readonly IInfrastructure _infrastrucature;
        public ViewModel(IInfrastructure infrasturcture)
        {
            _infrastrucature = infrasturcture;
            Console.WriteLine($"Infrastructure : {_infrastrucature.GetHashCode()}");
        }
    }
}
