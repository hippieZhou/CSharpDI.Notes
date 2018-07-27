using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace _13.UnityDI
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterType<ICompany, Company>();
            unityContainer.RegisterType<IEmployee, Employee>();

            IEmployee emp = unityContainer.Resolve<IEmployee>();
            emp.DisplaySalary();

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }
}
