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
            #region Contract definitions

            //pre
            Contract.Requires(amount > 0);
            //post
            Contract.Ensures(Contract.OldValue(this.balance) < balance);

            #endregion

            return ChangeBalance(balance + amount);
        }

        public double Withdraw(double amount)
        {
            #region Contract definitions

            //pre
            Contract.Requires(amount > 0);
            //post
            Contract.EnsuresOnThrow<WithdrawExceededException>(Contract.OldValue<double>(amount) > balance);
            Contract.Ensures(Contract.OldValue(balance) > balance);

            #endregion

            if (amount > balance) throw new WithdrawExceededException("Cannot withdraw more than available");
            return ChangeBalance(balance - amount);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public double ChangeBalance(double newBalance)
        {
            return balance = newBalance;
        }


        public class WithdrawExceededException : Exception
        {
            public WithdrawExceededException()
            {
            }

            public WithdrawExceededException(string message)
                : base(message)
            {
            }

            public WithdrawExceededException(string message, Exception inner)
                : base(message, inner)
            {
            }
        }
    }
}