
namespace CP380_B1_BlockList.Models
{
    public enum TransactionTypes
    {
        BUY, SELL, GRANT
    }

    public class Payload
    {
        public string user { get; set; }
        public TransactionTypes tType { get; set; }
        public int amount { get; set; }
        public string item { get; set; }


        public Payload(string userName, TransactionTypes trType, int amount, string item)
        {
            this.user = userName;
            this.tType = trType;
            this.amount = amount;
            this.item = item;
        }
    }
}
