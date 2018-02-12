using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public static class Bank
    {
        private static BankModel db = new BankModel();
        
        /// <summary>
        /// Create a Bank Account
        /// </summary>
        /// <param name="emailAddress">Email Address for the account</param>
        /// <param name="accountName">Name of the Account</param>
        /// <param name="accountType">Type Of Account</param>
        /// <returns>The Bank Account</returns>
        /// <exception cref="ArgumentNullException"/>
        public static Account CreateAccount(string emailAddress,
            string accountName ="Default Account",
            TypeOfAccount accountType = TypeOfAccount.Checking)
        {
            if (string.IsNullOrEmpty(emailAddress))
                throw new ArgumentNullException
                    ("emailAddress", "Email Address cannot be empty");
            var account = new Account
            {
                EmailAddress = emailAddress,
                AccountName = accountName,
                AccountType = accountType
            };
            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }

        public static Account EditAccount(Account account)
        {
            if (account == null)
                throw new ArgumentNullException("account", "Invalid Account!");

            Account oldAccount = FindAccount(account.AccountNumber);
            db.Entry(oldAccount).CurrentValues.SetValues(account);
            db.SaveChanges();

            return account;
        }

        public static Account FindAccount(int accountNumber)
        {
            var oldAccount = db.Accounts.Find(accountNumber);
            if (oldAccount == null)
                throw new ArgumentOutOfRangeException("account", "Invalid Account Number!");
            return oldAccount;
        }

        public static List<Account> GetAllAccounts(string emailAddress)
        {
            return db.Accounts.Where(a => a.EmailAddress == emailAddress).ToList();
        }

        public static List<Transaction> GetAllTransactions(int accountNumber)
        {
            return db.Transactions.Where(t => t.AccountNumber == accountNumber).OrderByDescending(t => t.TransactionDate).ToList();
        }
        public static void Deposit(int accountNumber, decimal amount)
        {
            var account = db.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            if(account != null)
            {
                account.Deposit(amount);
                var transaction = new Transaction
                {
                    TransactionDate = DateTime.Now,
                    TypeOfTransaction = TransactionType.Credit,
                    TransactionAmount = amount,
                    Description = "Deposit in a branch",
                    AccountNumber = account.AccountNumber
                };
                db.Transactions.Add(transaction);
                db.SaveChanges();
            }
        }

        public static void Withdraw(int accountNumber, decimal amount)
        {
            var account = db.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            if (account != null)
            {
                account.Withdraw(amount);
                db.SaveChanges();
            }
        }
    }
}
