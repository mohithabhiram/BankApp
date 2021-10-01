using System;
using System.Collections.Generic; 
namespace BANK
{
    class DisplayMenu
    {
        public void NextMenu(){
            BankFunctions b = new BankFunctions();
			Console.WriteLine("Enter 1 for Creating Account,2 for Withdrawal, 3 for Deposit, 4 for Transferring Amount  ,5 for Transaction History, 6 Logout");
			int Choice = Convert.ToInt32(Console.ReadLine());
			switch (Choice) {
                case 1:
                    b.CreateAccount();
                    break;
				case 2 : 
					b.Withdraw();
					break;
				case 3:
					b.Deposit();
					break;
                case 4:
                    b.Transfer();
                    break;
				case 5:
                	b.TransactionHistory();
					break;
				case 6:
                	b.Logout();
					break;
			}
		
	
        }
    }
}