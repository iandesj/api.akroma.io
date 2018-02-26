namespace Akroma.Persistence.SQL.Model
{
    public class TransactionEntity : BaseEntity
    {
        public string Hash { get; set; }
        public string Nonce { get; set; }
        public string BlockHash { get; set; }
        public int BlockNumber { get; set; }
        public int TransactionIndex { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal Value { get; set; }
        public string Gas { get; set; }
        public string GasPrice { get; set; }
        public long Timestamp { get; set; }
        public string Input { get; set; }

        public Domain.Transactions.Models.Transaction ToTransaction()
        {
            return new Domain.Transactions.Models.Transaction(Hash, Nonce, BlockHash, BlockNumber, TransactionIndex, From, To, Value,
                Gas, GasPrice, Timestamp, Input);
        }
    }
}
