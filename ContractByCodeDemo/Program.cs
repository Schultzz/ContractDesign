using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractByCodeDemo
{
    public class Program
    {
        Account account = new Account(1000);

        public Program()
        {
            //account.Deposit(-10);
            //account.Withdraw(1000);

            Console.WriteLine("Would you [d]eposit or [w]ithdraw money? 'eg. d 100'");
            while (true)
            {
                try
                {
                    var input = Console.ReadLine().Split(' ');
                    var option = input[0];
                    var amount = Double.Parse(input[1]);

                    if (option.Equals("d"))
                    {
                        Console.WriteLine("Balance: " + account.Deposit(amount));
                    }
                    else
                    {
                        Console.WriteLine("Balance: " + account.Withdraw(amount));
                    }
                }
                catch (Account.WithdrawExceededException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
        }
    }
}