using System;
using System.Collections.Generic;

namespace CP380_B1_BlockList.Models
{
    public class BlockList
    {

        public IList<Block> Chain { get; set; }

        public int Difficulty { get; set; } = 2;

        public BlockList()
        {
            Chain = new List<Block>();
            MakeFirstBlock();
        }

        public void MakeFirstBlock()
        {
            var block = new Block(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt"), null, new List<Payload>());
            block.Mine(Difficulty);
            Chain.Add(block);
        }

        public void AddBlock(Block block)
        {
            // TODO

            var s= block.PreviousHash;
            block.PreviousHash = s;
            Chain.Add(block);
        }

        public bool IsValid()
        {
            // TODO
            int co=Chain.Count;
            var one= Chain[co - 1].Hash;
            var two = Chain[co - 1].PreviousHash;
            //Console.WriteLine(Chain[co - 2].Hash+"--"+Chain[co - 1].PreviousHash );
            bool tf = true ;

            for(int i=1;i<Chain.Count;i++)
            {
                if ((Chain[co - (i+1)].Hash).ToString() == (Chain[co - i].PreviousHash).ToString().TrimStart('"').TrimEnd('"'))
                {
                    tf = true;
                }
                else
                {
                    return false;
                }

            }
            return tf;

        }
    }
}
