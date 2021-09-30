using System;
using System.Collections.Generic; 
				
public class Bank
{
	public static void Main()
	{
        Console.WriteLine("---Create Account---");
		Console.WriteLine("Enter username: ");
		string username  = Console.ReadLine();
		BankAccount newAccount = new BankAccount(username,10000);
	}
}

public class BankAccount:Bank {
	List <double> DepositList = new List<double>();
    List <double> WithdrawList = new List<double>();
	public string username {get; set;}

    public double Balance {get; set;}
	
	public BankAccount (string username, double Balance) {
		this.username = username;
		this.Balance = Balance;
        Console.WriteLine("Account Created");
		Console.WriteLine("Username: {0} , Balance: {1}", username, Balance);
		NextMenu();
	}
	
	public void NextMenu () {
		double balance = Balance;
		Console.WriteLine("Enter 1 for Withdrawal, 2 for Deposit, 3 for Transaction History, 4 Logout");
		int Choice = Convert.ToInt32(Console.ReadLine());
		switch (Choice) {
			case 1 : 
				Withdraw();
				break;
			case 2:
				Deposit();
				break;
			case 3:
                TransactionHistory();
				break;
			case 4:
                Logout();
				break;
		}
	}
	
	public double Withdraw () {
		Console.WriteLine("Available Balance: {0}", Balance);
		Console.WriteLine("How much would you like to withdraw?: ");
		double WithdrawAmt = Convert.ToDouble(Console.ReadLine());
        WithdrawList.Add(WithdrawAmt);
		Balance -= WithdrawAmt;
		Console.WriteLine(Balance);
		NextMenu();
		return WithdrawAmt;
	}
	
	public double Deposit() {
		Console.WriteLine("Available Balance: {0}", Balance);
		Console.WriteLine("How much would you like to deposit?: ");
		double DepositAmt = Convert.ToDouble(Console.ReadLine());
		
	
		DepositList.Add(DepositAmt);
		
		Balance = Balance + DepositAmt;
		Console.WriteLine(Balance);
		NextMenu();
		return DepositAmt;
	}
	
	public void Logout(){  
		Console.WriteLine("Thank you " + username);
	}
	
	public void TransactionHistory() {
        Console.WriteLine("---Deposits---");
        foreach (double i in DepositList) {
			Console.WriteLine("Deposit History: " + i);
        }
        Console.WriteLine("---Withdrawals---");
		foreach (double i in WithdrawList) {
			Console.WriteLine("Withdraw History: " + i);
		}
        NextMenu();
	}
	
}
