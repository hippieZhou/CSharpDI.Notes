using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Attributes;

namespace _13.UnityDI
{
    public class Employee : IEmployee
    {
        [Dependency]
        public ICompany PropertyInjectionCompany { get; set; }
        public ICompany ConstructorInjectionCompany { get; set; }
        public ICompany MethodInjectionCompany { get; set; }

        [InjectionConstructor]
        public Employee(ICompany tmpCompany)
        {
            ConstructorInjectionCompany = tmpCompany;
        }

        [InjectionMethod]
        public void Initialize(ICompany tmpCompany)
        {
            MethodInjectionCompany = tmpCompany;
        }

        public void DisplaySalary()
        {
            PropertyInjectionCompany.ShowSalary();
            ConstructorInjectionCompany.ShowSalary();
            MethodInjectionCompany.ShowSalary();

            Console.WriteLine($"Property Injection Object Hash Code is {PropertyInjectionCompany.GetHashCode()}");
            Console.WriteLine($"Constructor Injection Object Hash Code is {ConstructorInjectionCompany.GetHashCode()}");
            Console.WriteLine($"Method Injection Object Hash Code is {MethodInjectionCompany.GetHashCode()}");
        }
    }
}
