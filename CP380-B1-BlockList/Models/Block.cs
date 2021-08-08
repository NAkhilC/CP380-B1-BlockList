using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace CP380_B1_BlockList.Models
{
    public class Block
    {
        public int Nonce { get; set; } = 0;
        public DateTime TimeStamp { get; set; }
        public string PreviousHash { get; set; }
        public string Hash { get; set; }
        public List<Payload> Data { get; set; }

        public Block()
        {

        }
        public Block(DateTime timeStamp, string previousHash, List<Payload> data)
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
            SHA256 sha256 = SHA256.Create();
            var json = JsonSerializer.Serialize(Data);

            //
            // TODO
            //


            var input = Encoding.ASCII.GetBytes($"{TimeStamp}-{PreviousHash ?? ""}-{Data}-{Nonce}");
            var output = sha256.ComputeHash(input);

            return Convert.ToBase64String(output);
        }

        public void Mine(int difficulty)
        {
            var cvalues = new string('C', difficulty);
            while (this.Hash == null || this.Hash.Substring(0, difficulty) != cvalues)
            {
                this.Nonce++;
                this.Hash = this.CalculateHash();
            }
        }
    }
}
