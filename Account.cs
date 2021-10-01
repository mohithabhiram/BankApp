using System;
using System.Collections.Generic; 
namespace BANK{
    class Account{
        public string username;
        public int accountNo;
        public int pin;
        public double balance;
        public List<double> DepositList;
        public List<double> WithdrawList;
        public Account(string username,int accountNo,int pin)
        {
            this.username=username;
            this.accountNo=accountNo;
            this.pin=pin;
            this.balance=10000;
            this.DepositList = new List<double>();
            this.WithdrawList = new List<double>();
        }
        public int GetAccountNo()
        {
            return this.accountNo;
        }
        public int GetPin()
        {
            return this.pin;
        }
        public double getBalance()
        {
            return this.balance;
        }
    }
}