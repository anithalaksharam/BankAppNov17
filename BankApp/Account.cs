using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{

    public enum TypeOfAccount
    {
        Checking,
        Savings,
        CD,
        Loan
    }

    /// <summary>
    /// This is about a bank account
    /// for chase
    /// </summary>
    public class Account
    {
        #region Properties
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int AccountNumber { get; private set; }
        [StringLength(100,ErrorMessage ="Email address should be of 50 characters in length")]
        [Required]
        public string EmailAddress { get; set; }
        public string AccountName { get; set; }
        [Required]
        public TypeOfAccount AccountType { get; set; }
        public decimal Balance { get; private set; }
        #endregion

        #region Constructor
        public Account()
        {
        }

    #endregion

    #region Methods
    /// <summary>
    /// Deposit money into your account
    /// </summary>
    /// <param name="amount">Amount to be deposited</param>
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
