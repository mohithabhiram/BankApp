using System;
using System.Collections.Generic; 
namespace BANK
{
    public class SystemGeneratedInstructions
    {
        public static int AskAccountNo()
        {
            Console.WriteLine("Enter your account number");
            int accountNo = int.Parse(Console.ReadLine());
            return accountNo;
        }
        public static int AskPin()
        {
            Console.WriteLine("Enter your pin");
            int pinNo = int.Parse(Console.ReadLine());
            return pinNo;
        }
    }
}