using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ConcreteClass
{
    class Program
    {
        static void Main(string[] args)
        {
            var fooSide3 = new Polygon3(8);
            Console.WriteLine($"Perimeter:{fooSide3.GetPerimeter()}");
            Console.WriteLine($"Area:{fooSide3.GetArea()}");

            var fooSide4 = new Polugon4(8);
            Console.WriteLine($"Perimeter:{fooSide4.GetPerimeter()}");
            Console.WriteLine($"Area:{fooSide4.GetArea()}");

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }

    public class Polygon
    {
        public int Side { get; set; }
        public double Length { get; set; }
        public Polygon(int side, double length)
        {
            this.Side = side;
            this.Length = length;
        }

        public double GetPerimeter() => Side * Length;
        public virtual double GetArea() => throw new NotImplementedException();
    }

    public class Polygon3 : Polygon
    {
        public Polygon3(double length) : base(3, length)
        {
        }
        public override double GetArea() => Length * Length * Math.Sqrt(3) / 4;
    }

    public class Polugon4 : Polygon
    {
        public Polugon4(double length) : base(4, length)
        {
        }
        public override double GetArea() => Length * Length;
    }
}
