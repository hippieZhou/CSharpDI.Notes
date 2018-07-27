using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.UnityDI
{
    public class Company : ICompany
    {
        public Company()
        {
            Console.WriteLine($"Compay Object Hash Code = {this.GetHashCode()}");
        }
        public void ShowSalary()
        {
            Console.WriteLine("Your slary is 22 K");
        }
    }
}
