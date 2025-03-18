using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainAssignment
{
    class Blockchain
    {
        // List of block objects forming the blockchain
        public List<Block> blocks;

        // Maximum number of transactions per block
        private int transactionsPerBlock = 5;

        // List of pending transactions to be mined
        public List<Transaction> transactionPool = new List<Transaction>();

        // Default Constructor - initialises the list of blocks and generates the genesis block
        public Blockchain()
        {
            blocks = new List<Block>()
            {
                new Block() // Create and append the Genesis Block
            };
        }

        // Prints the block at the specified index to the UI
        public String GetBlockAsString(int index)
        {
            // Check if referenced block exists
            if (index >= 0 && index < blocks.Count)
                return blocks[index].ToString(); // Return block as a string
            else
                return "No such block exists";
        }

        // Retrieves the most recently appended block in the blockchain
        public Block GetLastBlock()
        {
            return blocks[blocks.Count - 1];
        }

        // Retrieve pending transactions and remove from pool
        public List<Transaction> GetPendingTransactions(MiningMode mode)
        {
            // Determine the number of transactions to retrieve dependent on the number of pending transactions and the limit specified
            int n = Math.Min(transactionsPerBlock, transactionPool.Count);

            if (mode == MiningMode.Greedy)
            {
                transactionPool.Sort((x, y) => y.fee.CompareTo(x.fee));
            }
            else if (mode == MiningMode.Altruistic)
            {
                transactionPool.Sort((x, y) => x.timestamp.CompareTo(y.timestamp));
            }
            else if (mode == MiningMode.Random)
            {
                Random rng = new Random();
                int i = transactionPool.Count;
                while (i > 1)
                {
                    i--;
                    int k = rng.Next(i + 1);
                    Transaction value = transactionPool[k]; // swap the values around
                    transactionPool[k] = transactionPool[i];
                    transactionPool[i] = value;
                }
            }

            // "Pull" transactions from the transaction list (modifying the original list)
            List<Transaction> transactions = transactionPool.GetRange(0, n);
            transactionPool.RemoveRange(0, n);

            // Return the extracted transactions
            return transactions;
        }

        // Check validity of a blocks hash by recomputing the hash and comparing with the mined value
        public static bool ValidateHash(Block b)
        {
            String rehash = b.CreateHash(b.nonce);
            return rehash.Equals(b.hash);
        }

        // Check validity of the merkle root by recalculating the root and comparing with the mined value
        public static bool ValidateMerkleRoot(Block b)
        {
            String reMerkle = Block.MerkleRoot(b.transactionList);
            return reMerkle.Equals(b.merkleRoot);
        }

        // Check the balance associated with a wallet based on the public key
        public double GetBalance(String address)
        {
            // Accumulator value
            double balance = 0;

            // Loop through all approved transactions in order to assess account balance
            foreach(Block b in blocks)
            {
                foreach(Transaction t in b.transactionList)
                {
                    if (t.recipientAddress.Equals(address))
                    {
                        balance += t.amount; // Credit funds recieved
                    }
                    if (t.senderAddress.Equals(address))
                    {
                        balance -= (t.amount + t.fee); // Debit payments placed
                    }
                }
            }
            return balance;
        }

        // Output all blocks of the blockchain as a string
        public override string ToString()
        {
            return String.Join("\n", blocks);
        }
    }
}
