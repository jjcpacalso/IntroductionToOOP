﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToOOP
{
    public class BankAccount
    {
        private static int s_accountNumberSeed = 1234567890;
        private readonly decimal _minimumBalance;
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in _allTransactions) 
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }

        private List<Transaction> _allTransactions = new List<Transaction>();

        public BankAccount(string name, decimal initialBalance): this(name, initialBalance, 0)
        {}

        public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
        {
            this.Owner = name;
            Number = s_accountNumberSeed.ToString();
            s_accountNumberSeed++;
            _minimumBalance = minimumBalance;
            if (initialBalance > 0)
            {
                MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
            }
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            Transaction deposit = new Transaction(amount, date, note);
            _allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positibe");
            }
            Transaction? overdraftTransaction = CheckWithdrawalLimit(Balance - amount < _minimumBalance);
            Transaction withdrawal = new Transaction(-amount, date, note);
            _allTransactions.Add(withdrawal);

            if (overdraftTransaction != null)
            {
                _allTransactions.Add(overdraftTransaction);
            }
        }

        protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
        {
            if (isOverdrawn)
            {
                throw new InvalidOperationException("Insufficient funds");
            }
            else
            {
                return default;
            }
        }

        public string GetAccountHistory()
        {
            StringBuilder report = new StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach(Transaction item in _allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }
            return report.ToString();
        }

        public virtual void PerformMonthEndTransaction()
        {
        }
    }

}
