using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExplicitImp
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleClass fooSampleClass = new SampleClass();
            IControl fooIControl = (IControl)fooSampleClass;
            ISurface fooISurface = (ISurface)fooSampleClass;

            Console.Write("fooSampleClass.Paint()'s result is :");
            fooSampleClass.Paint();
            Console.Write("fooIControl.Paint()'s result is:");
            fooIControl.Paint();
            Console.Write("fooISurface.Paint()'s result is:");
            fooISurface.Paint();
            Console.ReadKey();
        }
    }

    public interface IControl
    {
        void Paint();
    }

    public interface ISurface
    {
        void Paint();
    }

    public class SampleClass : IControl, ISurface
    {
        public void Paint()
        {
            Console.WriteLine("This is SampleClass's Paint");
        }

        void IControl.Paint()
        {
            Console.WriteLine("This is IControl's Paint");
        }

        void ISurface.Paint()
        {
            Console.WriteLine("This is ISurface's Paint");
        }
    }
}
