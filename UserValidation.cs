using System;
using System.Collections.Generic; 

namespace BANK
{
    class UserValidation
    {
        public static bool isValidAccount(Dictionary<int, Account> Users,int accountNo)
        {
            if (Users.ContainsKey(accountNo))
                return true;
            else
                return false;
        }
        public static bool isValidPin(Dictionary<int,Account> Users,int pinNo,int accountNo)
        {
            if (pinNo != Users[accountNo].pin)
            {
                    Console.WriteLine("Invalid Pin");
                    return false;
            }
            return true;
        }
    }
}