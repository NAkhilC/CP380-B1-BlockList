using System;
using CP380_B1_BlockList.Models;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;

namespace CP380_B1_BlockList
{
    class Program
    {
        static void Main(string[] args)
        {
            var myChain = new BlockList();

            List<Payload> data = new()
            { 
                new Payload("user", TransactionTypes.GRANT, 10, null), 
                new Payload("user", TransactionTypes.BUY, 10, "10C"),
                //new Payload("user", TransactionTypes.SELL, 100, "1009C"),
                  // new Payload("user", TransactionTypes.BUY, 10, "10Ckkk"),
               // new Payload("user", TransactionTypes.GRANT, 180, "100C"),
            };
            int count = myChain.Chain.Count;
            //Console.WriteLine(count);
            string prevhash=JsonSerializer.Serialize(myChain.Chain[count-1].Hash);
            var block = new Block(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt"), prevhash , data);

            myChain.AddBlock(block);

            var json = JsonSerializer.Serialize(myChain.Chain);
            Console.WriteLine(PrettyJson.MakePretty(json));

            Console.WriteLine($"Is the chain valid --> {myChain.IsValid()}");
        }
    }
}
