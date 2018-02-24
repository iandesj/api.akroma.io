using System.Collections.Generic;
using Akroma.Domain.Transactions.Models;

namespace Akroma.Domain.Addressess.Model
{
    public class Address
    {
        public Address(string hash, string balance, int mined, int page, int pages, int totalTransaction, int transacionCountFrom, int transacionCountTo, IEnumerable<Transaction> transactions)
        {
            Hash = hash;
            Balance = balance;
            Mined = mined;
            TransactionsInitiatedCount = totalTransaction;
            Page = page;
            Pages = pages;
            Transactions = transactions;
            TotalTransactions = totalTransaction;
            TransacionCountFrom = transacionCountFrom;
            TransacionCountTo = transacionCountTo;
        }

        public int TransactionsInitiatedCount { get; }

        public string Hash { get; }
        public string Balance { get; set; } //set in the query handler (does not come from db)
        public int Mined { get; }
        public int Page { get; }
        public int Pages { get; }

        public int TotalTransactions { get; }
        public int TransacionCountFrom { get; }
        public int TransacionCountTo { get; }
        public IEnumerable<Transaction> Transactions { get; }
    }
}
