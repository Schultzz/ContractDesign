using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ContractByCodeDemo
{
    public class Account
    {
        private double balance;
        

        public Account(double balance)
        {
            this.balance = balance;
        } 

        public double Deposit(double amount)
        {
            return ChangeBalance(balance + amount);
        }

        public double Withdraw(double amount)
        {
            return ChangeBalance(balance - amount);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public double ChangeBalance(double newBalance)
        {
            return balance = newBalance;
        }


    }
}
