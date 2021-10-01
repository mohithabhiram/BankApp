using System;
using System.Collections;
using System.Collections.Generic;
namespace BANK
{
    class BankFunctions
    {
        public static Dictionary<int, Account> Users;
        public static List<double> DepositList;
        public static List<double> WithdrawList;

        static BankFunctions()
        {
            Users = new Dictionary<int,Account>();
            DepositList = new List<double>();
    	    WithdrawList = new List<double>(); 
        }

        public void CreateAccount()
        {
            Console.WriteLine("Enter username: ");
			string username  = Console.ReadLine();
            Console.WriteLine("Set your account number");
            int accountNo = int.Parse(Console.ReadLine());
            while(Users.ContainsKey(accountNo))
            {
                Console.WriteLine("This Account Number already exists!, Please choose some other number");
                accountNo = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Set your pin");
            int pin = int.Parse(Console.ReadLine());
            Account acc = new Account(username,accountNo,pin);
            Users.Add(acc.accountNo, acc);
            DisplayMenu dm = new DisplayMenu();
            dm.NextMenu();
        }

        public void Withdraw()
        {
            int accountNo = SystemGeneratedInstructions.AskAccountNo();
            if(UserValidation.isValidAccount(Users,accountNo))
            {
                int pinNo = SystemGeneratedInstructions.AskPin();
                if(UserValidation.isValidPin(Users,pinNo,accountNo))
                {
                    Console.WriteLine("Enter the amount to withdraw");
                    double WithdrawAmt = Math.Abs(double.Parse(Console.ReadLine()));
                    if (WithdrawAmt > Users[accountNo].balance)
                    {
                        Console.WriteLine("Insufficient Balance");
                        return;
                    }
                    Users[accountNo].balance -= WithdrawAmt;
                    Users[accountNo].WithdrawList.Add(WithdrawAmt);
                    Console.WriteLine("Balance = "+Users[accountNo].balance);
                }
                else
                {
                    return;
                }               
            }
            else
            {
                Console.WriteLine("No such account exists");
            }
            DisplayMenu dm = new DisplayMenu();
            dm.NextMenu();
        }
        

        public void Deposit()
        {
            int accountNo = SystemGeneratedInstructions.AskAccountNo();
            if (Users.ContainsKey(accountNo))
            {
                int pinNo = SystemGeneratedInstructions.AskPin();
                if (pinNo != Users[accountNo].pin)
                {
                    Console.WriteLine("Invalid Pin");
                    return;
                }
                Console.WriteLine("Enter the amount to deposit");
                double DepositAmt = Math.Abs(double.Parse(Console.ReadLine()));
                Users[accountNo].balance += DepositAmt;
                Users[accountNo].DepositList.Add(DepositAmt);
                Console.WriteLine("Balance = "+Users[accountNo].balance);
            }
             else{
                Console.WriteLine("No such account exists");
             }
             DisplayMenu dm = new DisplayMenu();
             dm.NextMenu();
        }

        public void Transfer()
        {
            int accountNo = SystemGeneratedInstructions.AskAccountNo();
            if (Users.ContainsKey(accountNo))
            {
                int pinNo = SystemGeneratedInstructions.AskPin();
                if (pinNo != Users[accountNo].pin)
                {
                    Console.WriteLine("Invalid Pin");
                    return;
                }
                Console.WriteLine("Enter the beneficiary's account number");
                int beneficiaryAccountNo = int.Parse(Console.ReadLine());
                if(Users.ContainsKey(beneficiaryAccountNo))
                {
                    Console.WriteLine("Enter the amount to transfer");
                    int transferAmount = int.Parse(Console.ReadLine());
                    Users[beneficiaryAccountNo].balance += transferAmount;
                    Users[accountNo].balance -= transferAmount;
                    Console.WriteLine("Balance = "+Users[accountNo].balance);
                }
                else
                {
                    Console.WriteLine("No such account exists");
                }

            }
            else
            {
                Console.WriteLine("No such account exists");
            }
            DisplayMenu dm = new DisplayMenu();
            dm.NextMenu();
        }
            
        public void TransactionHistory() {
            int accountNo = SystemGeneratedInstructions.AskAccountNo();
            if (Users.ContainsKey(accountNo))
            {
                int pinNo = SystemGeneratedInstructions.AskPin();
                if (pinNo != Users[accountNo].pin)
                {
                    Console.WriteLine("Invalid Pin");
                    return;
                }
        	    Console.WriteLine("---Deposits---");
        	    foreach (double i in Users[accountNo].DepositList) {
				    Console.WriteLine("Deposit History: " + i);
        	    }
                if(Users[accountNo].DepositList.Count==0)
                {
                    Console.WriteLine("No Deposits to show");
                }
        	    Console.WriteLine("---Withdrawals---");
			    foreach (double i in Users[accountNo].WithdrawList) {
				    Console.WriteLine("Withdraw History: " + i);
			    }
                if(Users[accountNo].WithdrawList.Count==0)
                {
                    Console.WriteLine("No Withdrawals to show");
                }
            }
            else{
                Console.WriteLine("No such account exists");
                return;
            }
            Console.WriteLine("------------");
            Console.WriteLine("Total Balance:");
            Console.WriteLine("Balance = "+Users[accountNo].balance);
            DisplayMenu dm = new DisplayMenu();
            dm.NextMenu();

        }

        public void Logout(){  
			Console.WriteLine("Thank you!");
		}

    }
}