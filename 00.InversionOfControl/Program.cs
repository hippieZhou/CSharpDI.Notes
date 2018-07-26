using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00.InversionOfControl
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continueExecution = true;
            do
            {
                Console.Write("請輸入您的名字:");
                var firstName = Console.ReadLine();

                Console.Write("請輸入您的姓:");
                var lastName = Console.ReadLine();

                Console.Write("您是否要儲存? Y/N: ");

                var wantToSave = Console.ReadLine();

                if (wantToSave.ToUpper() == "Y")
                    SaveToDB(firstName, lastName);

                Console.Write("您是否要結束離開? Y/N: ");

                var wantToExit = Console.ReadLine();

                if (wantToExit.ToUpper() == "Y")
                    continueExecution = false;

            } while (continueExecution);
        }

        private static void SaveToDB(string firstName, string lastName)
        {
            //在這裡需要將輸入的姓、名，寫入到資料庫內
            Console.WriteLine($"{lastName} {firstName} 已經寫入到資料庫內了");
        }
    }
}
