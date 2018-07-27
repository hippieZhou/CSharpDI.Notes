using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00.ControOverTheFlowOfAProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入您的");
            bool continueExecution = true;
            do
            {
                Console.Write("请输入您的名称:");
                var firstName = Console.ReadLine();

                Console.Write("请输入您的姓氏:");
                var lastName = Console.ReadLine();

                Console.Write("您是否要储存? Y/N: ");

                var wantToSave = Console.ReadLine();

                if (wantToSave.ToUpper() == "Y")
                    SaveToDB(firstName, lastName);

                Console.Write("您是否要结束离开? Y/N: ");

                var wantToExit = Console.ReadLine();

                if (wantToExit.ToUpper() == "Y")
                    continueExecution = false;

            } while (continueExecution);
        }

        private static void SaveToDB(string firstName, string lastName)
        {
            Console.WriteLine($"{lastName} {firstName} 已经写入数据库中");
        }
    }
}
