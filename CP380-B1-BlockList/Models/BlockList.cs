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
            var block = new Block(DateTime.Now, null, new List<Payload>());
            block.Mine(Difficulty);
            Chain.Add(block);
        }

        public void AddBlock(Block block)
        {
            Block blockva = GetBlock();
            block.Nonce = blockva.Nonce + 1;
            block.PreviousHash = blockva.Hash;
            block.Mine(this.Difficulty);
            Chain.Add(block);
        }

        public Block GetBlock()
        {
            //get the last value in the chain
            return Chain[Chain.Count - 1];
        }

        public bool IsValid()
        {
            for (int i = 1; i < Chain.Count; i++)
            {
                Block firstblock = Chain[i];
                Block last = Chain[i - 1];

                if (firstblock.Hash != firstblock.CalculateHash())
                {
                    return false;
                }

                if (firstblock.PreviousHash != last.Hash)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
