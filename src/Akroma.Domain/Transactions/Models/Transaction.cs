namespace Akroma.Domain.Transactions.Models
{
    public class Transaction
    {
        public Transaction(string hash, string nonce, string blockHash, int blockNumber,
            int transactionIndex, string from, string to, decimal value,
            string gas, string gasPrice, long timestamp, string input)
        {
            Hash = hash;
            Nonce = nonce;
            BlockHash = blockHash;
            BlockNumber = blockNumber;
            TransactionIndex = transactionIndex;
            From = from;
            To = to;
            Value = value;
            Gas = gas;
            GasPrice = gasPrice;
            Timestamp = timestamp;
            Input = input;
        }

        public string Hash { get; }
        public string Nonce { get; }
        public string BlockHash { get; }
        public int BlockNumber { get; }
        public int TransactionIndex { get; }
        public string From { get; }
        public string To { get; }
        public decimal Value { get; }
        public string Gas { get; }
        public string GasPrice { get; }
        public long Timestamp { get; }
        public string Input { get; }
    }
}
