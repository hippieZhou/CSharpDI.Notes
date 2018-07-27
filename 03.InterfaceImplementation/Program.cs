using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.InterfaceImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var fooSide3 = new Polygon3(8);
            Console.WriteLine($"Perimeter: {fooSide3.GetPerimeter()}");
            Console.WriteLine($"Area: {fooSide3.GetArea()}");

            var fooSide4 = new Polygon4(8);
            Console.WriteLine($"Perimeter: {fooSide4.GetPerimeter()}");
            Console.WriteLine($"Area: {fooSide4.GetArea()}");

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }

    public interface IPolygon
    {
        int Side { get; set; }
        double Length { get; set; }
        double GetPerimeter();
        double GetArea();
    }

    public class Polygon3 : IPolygon
    {
        public int Side { get; set; }
        public double Length { get; set; }
        public Polygon3(double length)
        {
            Side = 3;
            Length = length;
        }
        public double GetPerimeter() => Side * Length;
        public double GetArea() => Length * Length * Math.Sqrt(3) / 4;
    }

    public class Polygon4 : IPolygon
    {
        public int Side { get; set; }
        public double Length { get; set; }
        public Polygon4(double length)
        {
            Side = 4;
            Length = length;
        }
        public double GetPerimeter() => Side * Length;
        public double GetArea() => Length * Length;
    }
}
