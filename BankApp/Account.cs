using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    /// <summary>
    /// This is about a bank account
    /// for chase
    /// </summary>
    class Account
    {
        #region Properties
        public int AccountNumber { get; private set; }
        public string EmailAddress { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; private set; }
        #endregion

        #region Methods
        /// <summary>
        /// Deposti money into yiur account
        /// </summary>
        /// <param name="amount"></param>
        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            Balance -= amount;
        }
        #endregion
    }
}
