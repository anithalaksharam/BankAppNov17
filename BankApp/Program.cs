using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //reference, object, instance of a class
            var account = new Account
            {
                AccountName = "My checking",
                AccountType = TypeOfAccount.Checking,
                EmailAddress = "test@test.com"
            };
            
            account.Deposit(100.10M);
            Console.WriteLine($"AccountNumber :{account.AccountNumber}," +
                $"Email Address :{account.EmailAddress}, Balance :{account.Balance}, "+
                $"Account Type :{account.AccountType}");

            var account2 = new Account
            {
                EmailAddress = "test@test.com",
                AccountType = TypeOfAccount.Savings
            };
            
            account2.Deposit(100.10M);
            Console.WriteLine($"AccountNumber :{account2.AccountNumber}, " +
                $"Email Address :{account2.EmailAddress}, Balance :{account2.Balance}," +
                $" Account Type :{account2.AccountType}");
           
            Console.Read();



        }
    }
}
