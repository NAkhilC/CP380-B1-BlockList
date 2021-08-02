
namespace CP380_B1_BlockList.Models
{
    public enum TransactionTypes
    {
        BUY, SELL, GRANT
    }

    public class Payload
    {

        // TODO

        public string v1;
        public TransactionTypes gRANT;
        public  int v2;
        public object p;



        public Payload(string v1, TransactionTypes gRANT, int v2, object p)
        {
            this.v1 = v1;
            this.gRANT = gRANT;
            this.v2 = v2;
            this.p = p;
        }
    }
}
