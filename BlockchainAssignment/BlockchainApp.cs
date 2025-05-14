using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace BlockchainAssignment
{
    public partial class BlockchainApp : Form
    {
        // Global blockchain object
        private Blockchain blockchain;

        // Default App Constructor
        public BlockchainApp()
        {
            // Initialise UI Components
            InitializeComponent();
            // Create a new blockchain 
            blockchain = new Blockchain();
            // Update UI with an initalisation message
            UpdateText("New blockchain initialised!");
        }

        /* PRINTING */
        // Helper method to update the UI with a provided message
        private void UpdateText(String text)
        {
            output.Text = text;
        }

        // Print entire blockchain to UI
        private void ReadAll_Click(object sender, EventArgs e)
        {
            UpdateText(blockchain.ToString());
        }

        // Print Block N (based on user input)
        private void PrintBlock_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(blockNo.Text, out int index))
                UpdateText(blockchain.GetBlockAsString(index));
            else
                UpdateText("Invalid Block No.");
        }

        // Print pending transactions from the transaction pool to the UI
        private void PrintPendingTransactions_Click(object sender, EventArgs e)
        {
            UpdateText(String.Join("\n", blockchain.transactionPool));
        }

        /* WALLETS */
        // Generate a new Wallet and fill the public and private key fields of the UI
        private void GenerateWallet()
        {
            Wallet.Wallet myNewWallet = new Wallet.Wallet(out string privKey);

            publicKey.Text = myNewWallet.publicID;
            privateKey.Text = privKey;
        }

        private void GenerateWallet_Click(object sender, EventArgs e)
        {
            GenerateWallet();
        }

        // Validate the keys loaded in the UI by comparing their mathematical relationship
        private void ValidateKeys_Click(object sender, EventArgs e)
        {
            if (Wallet.Wallet.ValidatePrivateKey(privateKey.Text, publicKey.Text))
                UpdateText("Keys are valid");
            else
                UpdateText("Keys are invalid");
        }

        // Check the balance of current user
        private void CheckBalance_Click(object sender, EventArgs e)
        {
            UpdateText(blockchain.GetBalance(publicKey.Text).ToString() + " Assignment Coin");
        }


        /* TRANSACTION MANAGEMENT */
        // Create a new pending transaction and add it to the transaction pool
        private void CreateTransaction_Click(object sender, EventArgs e)
        {
            Transaction transaction = new Transaction(publicKey.Text, reciever.Text, Double.Parse(amount.Text), Double.Parse(fee.Text), privateKey.Text);
            /* TODO: Validate transaction */
            blockchain.transactionPool.Add(transaction);
            UpdateText(transaction.ToString());
        }

        private void newBlock(bool multithreaded)
        {

            var mode = new MiningMode();
            if (GreedyButton.Checked)
                mode = MiningMode.Greedy;
            else if (AltruisticButton.Checked)
                mode = MiningMode.Altruistic;
            else if (RandomButton.Checked)
                mode = MiningMode.Random;

            // Retrieve pending transactions to be added to the newly generated Block
            List<Transaction> transactions = blockchain.GetPendingTransactions(mode);

            // Create and append the new block - requires a reference to the previous block, a set of transactions and the miners public address (For the reward to be issued)
            Block newBlock = new Block(blockchain.GetLastBlock(), transactions, publicKey.Text, multithreaded);
            blockchain.blocks.Add(newBlock);

            UpdateText(blockchain.ToString());
        }

        /* BLOCK MANAGEMENT */
        // Conduct Proof-of-work in order to mine transactions from the pool and submit a new block to the Blockchain
        private void newBlockMultiThread_Click(object sender, EventArgs e)
        {
            newBlock(multithreaded: true);
        }

        private void newBlockSingleThread_Click(object sender, EventArgs e)
        {
            newBlock(multithreaded: false);
        }


        /* BLOCKCHAIN VALIDATION */
        // Validate the integrity of the state of the Blockchain
        private void Validate_Click(object sender, EventArgs e)
        {
            // CASE: Genesis Block - Check only hash as no transactions are currently present
            if (blockchain.blocks.Count == 1)
            {
                if (!Blockchain.ValidateHash(blockchain.blocks[0])) // Recompute Hash to check validity
                    UpdateText("Blockchain is invalid");
                else
                    UpdateText("Blockchain is valid");
                return;
            }

            for (int i = 1; i < blockchain.blocks.Count - 1; i++)
            {
                if (
                    blockchain.blocks[i].prevHash != blockchain.blocks[i - 1].hash || // Check hash "chain"
                    !Blockchain.ValidateHash(blockchain.blocks[i]) ||  // Check each blocks hash
                    !Blockchain.ValidateMerkleRoot(blockchain.blocks[i]) // Check transaction integrity using Merkle Root
                )
                {
                    UpdateText("Blockchain is invalid");
                    return;
                }
            }
            UpdateText("Blockchain is valid");
        }

        private void forgeBlock_Click(object sender, EventArgs e)
        {
            var stakes = blockchain.blocks
                .SelectMany(b => b.transactionList)
                .SelectMany(tx => new[] { tx.senderAddress, tx.recipientAddress })
                .Distinct()
                .Where(addr => addr != "Mine Rewards")
                .ToDictionary(
                    addr => addr,
                    addr => blockchain.GetBalance(addr)
                );

            if (stakes.Count == 0)
            {
                UpdateText("Cannot forge new block, no stakes!");
                return;
            }

            var validator = ValidatorPicker.Pick(stakes);

            var mode = new MiningMode();
            if (GreedyButton.Checked)
                mode = MiningMode.Greedy;
            else if (AltruisticButton.Checked)
                mode = MiningMode.Altruistic;
            else if (RandomButton.Checked)
                mode = MiningMode.Random;

            // Retrieve pending transactions to be added to the newly generated Block
            List<Transaction> transactions = blockchain.GetPendingTransactions(mode);

            // Create and append the new block - requires a reference to the previous block, a set of transactions and the miners public address (For the reward to be issued)
            Block newBlock = new Block(blockchain.GetLastBlock(), transactions, validator);
            blockchain.blocks.Add(newBlock);

            UpdateText(blockchain.ToString());
        }

        private void randomTransaction_Click(object sender, EventArgs e)
        {
            GenerateRandomTransaction();
        }

        private void GenerateRandomTransaction()
        {
            // Generate a random wallet for the sender
            GenerateWallet();
            string senderAddress = publicKey.Text;
            string senderPrivateKey = privateKey.Text;

            // Generate a random recipient address
            Wallet.Wallet randomWallet = new Wallet.Wallet(out _);
            string recipientAddress = randomWallet.publicID;

            // Generate random amount and fee
            Random random = new Random();
            double amount = Math.Round(random.NextDouble() * 10, 2); // Random amount between 0 and 10
            double fee = Math.Round(random.NextDouble() * 1, 2); // Random fee between 0 and 1

            // Create the transaction
            Transaction transaction = new Transaction(senderAddress, recipientAddress, amount, fee, senderPrivateKey);

            // Add the transaction to the transaction pool
            blockchain.transactionPool.Add(transaction);

            // Update the UI with the transaction details
            UpdateText(transaction.ToString());
        }

    }
}