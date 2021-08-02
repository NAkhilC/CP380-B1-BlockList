using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace CP380_B1_BlockList.Models
{
    public class Block
    {


        public int Nonce { get; set; }
        public string TimeStamp { get; set; }
        public string PreviousHash { get; set; }
        public string Hash { get; set; }
        public List<Payload> Data { get; set; }

        public Block(string timeStamp, string previousHash, List<Payload> data)
        {
            Nonce = 0;
            TimeStamp = timeStamp;
            PreviousHash = previousHash;
            Data = data;
            Hash = CalculateHash();
        }


        //
        // JSON serialisation:
        //   https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-how-to?pivots=dotnet-5-0
        //
        public string CalculateHash()
        {
            var sha256 = SHA256.Create();
            var json = JsonSerializer.Serialize(Data);
            var finaldata = "";

            if (PreviousHash == null)
            {
                Mine(Nonce);
                finaldata = TimeStamp + "-" + PreviousHash + "-" + (Nonce - 1) + "-[]";
            }
            else
            {
               // Console.WriteLine("Next");
                Mine(3);
               // Console.WriteLine(Nonce);
            if (PreviousHash != null)
            {
                 foreach (var field in Data)
                    {
                        var grant = "GRANT";
                        var Buy = "BUY";
                        var corr = grant.Equals(field.gRANT.ToString());
                        var corr1 = Buy.Equals(field.gRANT.ToString());
                        if (corr)
                        {
                            finaldata = TimeStamp + "-" + PreviousHash + "-" + (Nonce - 1) + "-" + "[{\"User\":\"" + field.v1 + "\",\"TransactionType\":2,\"Amount\":" + field.v2 + ",\"Item\":\"\"" + field.p + "}]";
                        }
                        else if (corr1)
                        {
                            finaldata = TimeStamp + "-" + PreviousHash + "-" + (Nonce - 1) + "-" + "[{\"User\":\"" + field.v1 + "\",\"TransactionType\":0,\"Amount\":" + field.v2 + ",\"Item\":\"" + field.p + "\"}]";
                        }
                        else
                        {
                            finaldata = TimeStamp + "-" + PreviousHash + "-" + (Nonce - 1) + "-" + "[{\"User\":\"" + field.v1 + "\",\"TransactionType\":1,\"Amount\":" + field.v2 + ",\"Item\":\"" + field.p + "\"}]";
                        }

                    }
            }
        }

            //
            // TODO
            //

            var inputString = finaldata; // TODO
            var inputBytes = Encoding.ASCII.GetBytes(inputString);
            var outputBytes = sha256.ComputeHash(inputBytes);
            var oo = Convert.ToBase64String(outputBytes);

            return Convert.ToBase64String(outputBytes);
        }

        public void Mine(int difficulty)
        {
            var finaldata = "";
            var sha256 = SHA256.Create();
            var oo="";
            var strings = "";
            for(int i=1;i<=difficulty;i++)
            {
                strings = strings + "C";
            }
            //Console.WriteLine(strings);
           

            if(PreviousHash==null)
            {
                Nonce = difficulty;
                do {
                    
                    finaldata = TimeStamp + "-" + PreviousHash + "-" + Nonce + "-[]";
                    var inputString = finaldata; // TODO
                    var inputBytes = Encoding.ASCII.GetBytes(inputString);
                    var outputBytes = sha256.ComputeHash(inputBytes);
                    oo = Convert.ToBase64String(outputBytes);
                    Nonce++;

                } while (!oo.StartsWith("CC"));

            }
            else
            {
                do
                {
                    foreach (var field in Data)
                    {
                        var grant = "GRANT";
                        var Buy = "BUY";
                        var corr = grant.Equals(field.gRANT.ToString());
                        var corr1 = Buy.Equals(field.gRANT.ToString());
                        if (corr)
                        {
                            finaldata = TimeStamp + "-" + PreviousHash + "-" + Nonce + "-" + "[{\"User\":\"" + field.v1 + "\",\"TransactionType\":2,\"Amount\":" + field.v2 + ",\"Item\":\"\"" + field.p + "}]";
                        }
                        else if (corr1)
                        {
                            finaldata = TimeStamp + "-" + PreviousHash + "-" + Nonce + "-" + "[{\"User\":\"" + field.v1 + "\",\"TransactionType\":0,\"Amount\":" + field.v2 + ",\"Item\":\"" + field.p + "\"}]";
                        }
                        else
                        {
                            finaldata = TimeStamp + "-" + PreviousHash + "-" + Nonce + "-" + "[{\"User\":\"" + field.v1 + "\",\"TransactionType\":1,\"Amount\":" + field.v2 + ",\"Item\":\"" + field.p + "\"}]";
                        }

                    }
                    var inputString = finaldata; // TODO
                    var inputBytes = Encoding.ASCII.GetBytes(inputString);
                    var outputBytes = sha256.ComputeHash(inputBytes);
                    oo = Convert.ToBase64String(outputBytes);
                    Nonce++;
                } while (!oo.StartsWith(strings));

                

            }
            // Console.WriteLine(TimeStamp + "--" + oo + "--" + Nonce);


        }
    }
}
