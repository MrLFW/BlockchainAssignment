﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace BlockchainAssignment
{
    class Block
    {
        /* Block Variables */
        private DateTime timestamp; // Time of creation

        private int index, // Position of the block in the sequence of blocks
            difficulty,
            prevDifficulty; // An arbitrary number of 0's to proceed a hash value

        public String prevHash, // A reference pointer to the previous block
            hash, // The current blocks "identity"
            merkleRoot,  // The merkle root of all transactions in the block
            minerAddress; // Public Key (Wallet Address) of the Miner

        public List<Transaction> transactionList; // List of transactions in this block

        // Proof-of-work
        public long nonce; // Number used once for Proof-of-Work and mining

        // Rewards
        public double reward; // Simple fixed reward established by "Coinbase"
        private double targetBlockTime = 15; // Target time between blocks in seconds
        private double miningTime;
        public double prevMiningTime; // Time taken to mine the previous block
        private string threadingType;
        const int threadCount = 4; // Hard-coded number of threads

        /* Genesis block constructor */
        public Block()
        {
            timestamp = DateTime.Now;
            index = 0;
            prevMiningTime = 0;
            difficulty = 4;
            transactionList = new List<Transaction>();
            hash = MineMultiThreaded();
        }

        /* New Block constructor */
        public Block(Block lastBlock, List<Transaction> transactions, String minerAddress, bool multithreaded)
        {
            timestamp = DateTime.Now;

            index = lastBlock.index + 1;
            prevHash = lastBlock.hash;
            prevMiningTime = lastBlock.miningTime;
            prevDifficulty = lastBlock.difficulty;
            difficulty = CalculateDifficulty();

            this.minerAddress = minerAddress; // The wallet to be credited the reward for the mining effort
            reward = 1.0; // Assign a simple fixed value reward
            transactions.Add(createRewardTransaction(transactions)); // Create and append the reward transaction
            transactionList = new List<Transaction>(transactions); // Assign provided transactions to the block

            merkleRoot = MerkleRoot(transactionList); // Calculate the merkle root of the blocks transactions
            hash = multithreaded ? MineMultiThreaded() : Mine(); // Conduct PoW to create a hash which meets the given difficulty requirement
        }

        // PROOF OF STAKE CONSTRUCTOR
        public Block(Block lastBlock, List<Transaction> transactions, String minerAddress)
        {
            timestamp = DateTime.Now;

            index = lastBlock.index + 1;
            prevHash = lastBlock.hash;
            prevMiningTime = lastBlock.miningTime;
            prevDifficulty = lastBlock.difficulty;
            difficulty = 0;

            this.minerAddress = minerAddress; // The wallet to be credited the reward for the mining effort
            reward = 0.1; // Less reward for proof of stake
            transactions.Add(createRewardTransaction(transactions)); // Create and append the reward transaction
            transactionList = new List<Transaction>(transactions); // Assign provided transactions to the block

            merkleRoot = MerkleRoot(transactionList); // Calculate the merkle root of the blocks transactions
            hash = Forge(); // Conduct PoW to create a hash which meets the given difficulty requirement
        }


        private int CalculateDifficulty()
        {
            return prevMiningTime < targetBlockTime ? prevDifficulty + 1 : prevDifficulty - 1;
        }

        /* Hashes the entire Block object */
        public String CreateHash(long nonce)
        {
            String hash = String.Empty;
            SHA256 hasher = SHA256Managed.Create();

            /* Concatenate all of the blocks properties including nonce as to generate a new hash on each call */
            String input = timestamp.ToString() + index + prevHash + nonce + merkleRoot;

            /* Apply the hash function to the block as represented by the string "input" */
            Byte[] hashByte = hasher.ComputeHash(Encoding.UTF8.GetBytes(input));

            /* Reformat to a string */
            foreach (byte x in hashByte)
                hash += String.Format("{0:x2}", x);

            return hash;
        }

        // Create a Hash which satisfies the difficulty level required for PoW
        public String MineMultiThreaded()
        {
            var stopwatch = Stopwatch.StartNew();
            Thread[] miners = new Thread[threadCount];
            bool found = false;
            String finalHash = String.Empty;
            long successfulNonce = 0;

            String re = new string('0', difficulty); // A string for analysing the PoW requirement

            object lockObject = new object();

            void MineThread(object threadId)
            {
                long threadNonce = (int)threadId; // TODO check we can cast to int then set as long
                String hash;

                while (!found)
                {
                    hash = CreateHash(threadNonce);

                    if (hash.StartsWith(re))
                    {
                        lock (lockObject)
                        {
                            if (!found)
                            {
                                found = true;
                                finalHash = hash;
                                successfulNonce = threadNonce;
                            }
                        }
                        break;
                    }
                    threadNonce += threadCount;
                }
            }

            for (int i = 0; i < threadCount; i++)
            {
                miners[i] = new Thread(MineThread);
                miners[i].Start(i);
            }

            foreach (var thread in miners)
            {
                thread.Join();
            }

            nonce = successfulNonce;
            stopwatch.Stop();
            miningTime = stopwatch.Elapsed.TotalSeconds;
            threadingType = "Multi";
            return finalHash;
        }

        public String Mine()
        {
            var stopwatch = Stopwatch.StartNew();
            nonce = 0; // Initalise the nonce
            String hash = CreateHash(nonce); // Hash the block
            String re = new string('0', difficulty); // A string for analysing the PoW requirement

            while (!hash.StartsWith(re)) // Check the resultant hash against the "re" string
            {
                nonce++; // Increment the nonce should the difficulty level not be satisfied
                hash = CreateHash(nonce); // Rehash with the new nonce as to generate a different hash
            }

            stopwatch.Stop();
            miningTime = stopwatch.Elapsed.TotalSeconds;
            threadingType = "Single";
            return hash; // Return the hash meeting the difficulty requirement
        }

        public String Forge()
        {
            var stopwatch = Stopwatch.StartNew();
            nonce = 0;
            String hash = CreateHash(nonce);
            stopwatch.Stop();
            miningTime = stopwatch.Elapsed.TotalSeconds;
            threadingType = "Single (PoS)";
            return hash;
        }


        // Merkle Root Algorithm - Encodes transactions within a block into a single hash
        public static String MerkleRoot(List<Transaction> transactionList)
        {
            List<String> hashes = transactionList.Select(t => t.hash).ToList(); // Get a list of transaction hashes for "combining"

            // Handle Blocks with...
            if (hashes.Count == 0) // No transactions
            {
                return String.Empty;
            }
            if (hashes.Count == 1) // One transaction - hash with "self"
            {
                return HashCode.HashTools.combineHash(hashes[0], hashes[0]);
            }
            while (hashes.Count != 1) // Multiple transactions - Repeat until tree has been traversed
            {
                List<String> merkleLeaves = new List<String>(); // Keep track of current "level" of the tree

                for (int i = 0; i < hashes.Count; i += 2) // Step over neighbouring pair combining each
                {
                    if (i == hashes.Count - 1)
                    {
                        merkleLeaves.Add(HashCode.HashTools.combineHash(hashes[i], hashes[i])); // Handle an odd number of leaves
                    }
                    else
                    {
                        merkleLeaves.Add(HashCode.HashTools.combineHash(hashes[i], hashes[i + 1])); // Hash neighbours leaves
                    }
                }
                hashes = merkleLeaves; // Update the working "layer"
            }
            return hashes[0]; // Return the root node
        }

        // Create reward for incentivising the mining of block
        public Transaction createRewardTransaction(List<Transaction> transactions)
        {
            double fees = transactions.Aggregate(0.0, (acc, t) => acc + t.fee); // Sum all transaction fees
            return new Transaction("Mine Rewards", minerAddress, (reward + fees), 0, ""); // Issue reward as a transaction in the new block
        }

        /* Concatenate all properties to output to the UI */
        public override string ToString()
        {
            return "[BLOCK START]"
                + "\nIndex: " + index
                + "\tTimestamp: " + timestamp
                + "\nPrevious Hash: " + prevHash
                + "\n-- PoW --"
                + "\nDifficulty Level: " + difficulty
                + "\nNonce: " + nonce
                + "\nHash: " + hash
                + $"\nMining Time: {miningTime:F3} seconds"
                + "\nThreading Type: " + threadingType
                + "\n-- Rewards --"
                + "\nReward: " + reward
                + "\nMiners Address: " + minerAddress
                + "\n-- " + transactionList.Count + " Transactions --"
                + "\nMerkle Root: " + merkleRoot
                + "\n" + String.Join("\n", transactionList)
                + "\n[BLOCK END]\n";
        }
    }
}
