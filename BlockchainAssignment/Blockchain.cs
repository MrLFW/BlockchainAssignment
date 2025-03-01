using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainAssignment
{
    class Blockchain
    {
        /* Blockchain Properties */
        List<Block> Blocks;

        /* Blockchain Constructor - Initialises a new blockchain with a single genesis block */
        public Blockchain()
        {
            Blocks = new List<Block>() {
                new Block()
            };
        }

        /* Helper function to get a block at a user specified index */
        public String getBlockAsString(int index)
        {
            if (index >= 0 && index < Blocks.Count)
                return Blocks[index].ToString();
            return "Block does not exist at index: " + index.ToString();
        }
    }
}
