using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainAssignment
{
    class Block
    {
        /** Block Properties */
        DateTime timestamp;
        int index;
        String hash, prevHash;

        /* Genesis Block Constructor */
        public Block()
        {
            this.timestamp = DateTime.Now;
            this.index = 0;
            this.prevHash = String.Empty; // No prior block hash
            this.hash = CreateHash();
        }

        /* Block Constructors */
        public Block(int index, String hash) 
        { 
            this.timestamp = DateTime.Now;
            this.index = index + 1;
            this.prevHash = hash;
            this.hash = CreateHash();
        }

        // Overloaded block constructor accepting a Block object
        public Block(Block prevBlock)
        {
            this.timestamp = DateTime.Now;
            this.index = prevBlock.index + 1;
            this.prevHash = prevBlock.hash;
            this.hash = CreateHash();
        }

        /* Generate a blocks hash using the SHA256 algorithm */
        public String CreateHash()
        {
            SHA256 hasher = SHA256Managed.Create(); 

            String input = index.ToString() + timestamp.ToString() + prevHash; 
            Byte[] hashByte = hasher.ComputeHash(Encoding.UTF8.GetBytes(input)); 

            String hash = string.Empty; 

            foreach (byte x in hashByte) 
                hash += String.Format("{0:x2}", x); 

            return hash;
        }

        /* Return a human-readable representation of a block */
        public override string ToString()
        {
            return
                "Index: " + index.ToString() + "\tTimestamp: " + timestamp.ToString() +
                "\nHash: " + hash +
                "\nPrevious Hash: " + prevHash;
        }
    }
}
