namespace BlockchainAssignment
{
    partial class BlockchainApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.output = new System.Windows.Forms.RichTextBox();
            this.printBlock = new System.Windows.Forms.Button();
            this.blockNo = new System.Windows.Forms.TextBox();
            this.generateWallet = new System.Windows.Forms.Button();
            this.publicKeyLabel = new System.Windows.Forms.Label();
            this.privateKeyLabel = new System.Windows.Forms.Label();
            this.publicKey = new System.Windows.Forms.TextBox();
            this.privateKey = new System.Windows.Forms.TextBox();
            this.validateKeys = new System.Windows.Forms.Button();
            this.createTransaction = new System.Windows.Forms.Button();
            this.fee = new System.Windows.Forms.TextBox();
            this.amount = new System.Windows.Forms.TextBox();
            this.feeLabel = new System.Windows.Forms.Label();
            this.amountLabel = new System.Windows.Forms.Label();
            this.reciever = new System.Windows.Forms.TextBox();
            this.recieverKeyLabel = new System.Windows.Forms.Label();
            this.newBlockMultiThread = new System.Windows.Forms.Button();
            this.printBlockchain = new System.Windows.Forms.Button();
            this.readPendingTransactions = new System.Windows.Forms.Button();
            this.validate = new System.Windows.Forms.Button();
            this.checkBalance = new System.Windows.Forms.Button();
            this.currentWalletLabel = new System.Windows.Forms.Label();
            this.transactionLabel = new System.Windows.Forms.Label();
            this.blocksLabel = new System.Windows.Forms.Label();
            this.validationLabel = new System.Windows.Forms.Label();
            this.newBlockSingleThread = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.GreedyButton = new System.Windows.Forms.RadioButton();
            this.AltruisticButton = new System.Windows.Forms.RadioButton();
            this.RandomButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // output
            // 
            this.output.BackColor = System.Drawing.SystemColors.InfoText;
            this.output.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.output.Location = new System.Drawing.Point(12, 12);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(460, 602);
            this.output.TabIndex = 0;
            this.output.Text = "";
            // 
            // printBlock
            // 
            this.printBlock.Location = new System.Drawing.Point(486, 121);
            this.printBlock.Margin = new System.Windows.Forms.Padding(2);
            this.printBlock.Name = "printBlock";
            this.printBlock.Size = new System.Drawing.Size(66, 25);
            this.printBlock.TabIndex = 1;
            this.printBlock.Text = "Block #";
            this.printBlock.UseVisualStyleBackColor = true;
            this.printBlock.Click += new System.EventHandler(this.PrintBlock_Click);
            // 
            // blockNo
            // 
            this.blockNo.Location = new System.Drawing.Point(556, 124);
            this.blockNo.Margin = new System.Windows.Forms.Padding(2);
            this.blockNo.Name = "blockNo";
            this.blockNo.Size = new System.Drawing.Size(24, 20);
            this.blockNo.TabIndex = 2;
            // 
            // generateWallet
            // 
            this.generateWallet.Location = new System.Drawing.Point(11, 660);
            this.generateWallet.Margin = new System.Windows.Forms.Padding(2);
            this.generateWallet.Name = "generateWallet";
            this.generateWallet.Size = new System.Drawing.Size(79, 55);
            this.generateWallet.TabIndex = 3;
            this.generateWallet.Text = "Generate New Wallet";
            this.generateWallet.UseVisualStyleBackColor = true;
            this.generateWallet.Click += new System.EventHandler(this.GenerateWallet_Click);
            // 
            // publicKeyLabel
            // 
            this.publicKeyLabel.AutoSize = true;
            this.publicKeyLabel.Location = new System.Drawing.Point(120, 674);
            this.publicKeyLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.publicKeyLabel.Name = "publicKeyLabel";
            this.publicKeyLabel.Size = new System.Drawing.Size(57, 13);
            this.publicKeyLabel.TabIndex = 4;
            this.publicKeyLabel.Text = "Public Key";
            // 
            // privateKeyLabel
            // 
            this.privateKeyLabel.AutoSize = true;
            this.privateKeyLabel.Location = new System.Drawing.Point(120, 698);
            this.privateKeyLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.privateKeyLabel.Name = "privateKeyLabel";
            this.privateKeyLabel.Size = new System.Drawing.Size(61, 13);
            this.privateKeyLabel.TabIndex = 5;
            this.privateKeyLabel.Text = "Private Key";
            // 
            // publicKey
            // 
            this.publicKey.Location = new System.Drawing.Point(185, 671);
            this.publicKey.Margin = new System.Windows.Forms.Padding(2);
            this.publicKey.Name = "publicKey";
            this.publicKey.Size = new System.Drawing.Size(187, 20);
            this.publicKey.TabIndex = 6;
            // 
            // privateKey
            // 
            this.privateKey.Location = new System.Drawing.Point(185, 695);
            this.privateKey.Margin = new System.Windows.Forms.Padding(2);
            this.privateKey.Name = "privateKey";
            this.privateKey.Size = new System.Drawing.Size(187, 20);
            this.privateKey.TabIndex = 7;
            // 
            // validateKeys
            // 
            this.validateKeys.Location = new System.Drawing.Point(376, 669);
            this.validateKeys.Margin = new System.Windows.Forms.Padding(2);
            this.validateKeys.Name = "validateKeys";
            this.validateKeys.Size = new System.Drawing.Size(87, 22);
            this.validateKeys.TabIndex = 8;
            this.validateKeys.Text = "Validate Keys";
            this.validateKeys.UseVisualStyleBackColor = true;
            this.validateKeys.Click += new System.EventHandler(this.ValidateKeys_Click);
            // 
            // createTransaction
            // 
            this.createTransaction.Location = new System.Drawing.Point(486, 288);
            this.createTransaction.Margin = new System.Windows.Forms.Padding(2);
            this.createTransaction.Name = "createTransaction";
            this.createTransaction.Size = new System.Drawing.Size(196, 26);
            this.createTransaction.TabIndex = 9;
            this.createTransaction.Text = "Create Transaction";
            this.createTransaction.UseVisualStyleBackColor = true;
            this.createTransaction.Click += new System.EventHandler(this.CreateTransaction_Click);
            // 
            // fee
            // 
            this.fee.Location = new System.Drawing.Point(646, 240);
            this.fee.Margin = new System.Windows.Forms.Padding(2);
            this.fee.Name = "fee";
            this.fee.Size = new System.Drawing.Size(36, 20);
            this.fee.TabIndex = 13;
            // 
            // amount
            // 
            this.amount.Location = new System.Drawing.Point(577, 240);
            this.amount.Margin = new System.Windows.Forms.Padding(2);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(36, 20);
            this.amount.TabIndex = 12;
            // 
            // feeLabel
            // 
            this.feeLabel.AutoSize = true;
            this.feeLabel.Location = new System.Drawing.Point(617, 243);
            this.feeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.feeLabel.Name = "feeLabel";
            this.feeLabel.Size = new System.Drawing.Size(25, 13);
            this.feeLabel.TabIndex = 11;
            this.feeLabel.Text = "Fee";
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Location = new System.Drawing.Point(530, 243);
            this.amountLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(43, 13);
            this.amountLabel.TabIndex = 10;
            this.amountLabel.Text = "Amount";
            // 
            // reciever
            // 
            this.reciever.Location = new System.Drawing.Point(563, 264);
            this.reciever.Margin = new System.Windows.Forms.Padding(2);
            this.reciever.Name = "reciever";
            this.reciever.Size = new System.Drawing.Size(119, 20);
            this.reciever.TabIndex = 15;
            // 
            // recieverKeyLabel
            // 
            this.recieverKeyLabel.AutoSize = true;
            this.recieverKeyLabel.Location = new System.Drawing.Point(488, 267);
            this.recieverKeyLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.recieverKeyLabel.Name = "recieverKeyLabel";
            this.recieverKeyLabel.Size = new System.Drawing.Size(71, 13);
            this.recieverKeyLabel.TabIndex = 14;
            this.recieverKeyLabel.Text = "Reciever Key";
            // 
            // newBlockMultiThread
            // 
            this.newBlockMultiThread.Location = new System.Drawing.Point(485, 91);
            this.newBlockMultiThread.Margin = new System.Windows.Forms.Padding(2);
            this.newBlockMultiThread.Name = "newBlockMultiThread";
            this.newBlockMultiThread.Size = new System.Drawing.Size(197, 26);
            this.newBlockMultiThread.TabIndex = 16;
            this.newBlockMultiThread.Text = "Generate New Block (Multi Thread)";
            this.newBlockMultiThread.UseVisualStyleBackColor = true;
            this.newBlockMultiThread.Click += new System.EventHandler(this.newBlockMultiThread_Click);
            // 
            // printBlockchain
            // 
            this.printBlockchain.Location = new System.Drawing.Point(584, 121);
            this.printBlockchain.Margin = new System.Windows.Forms.Padding(2);
            this.printBlockchain.Name = "printBlockchain";
            this.printBlockchain.Size = new System.Drawing.Size(98, 25);
            this.printBlockchain.TabIndex = 17;
            this.printBlockchain.Text = "Entire Chain";
            this.printBlockchain.UseVisualStyleBackColor = true;
            this.printBlockchain.Click += new System.EventHandler(this.ReadAll_Click);
            // 
            // readPendingTransactions
            // 
            this.readPendingTransactions.Location = new System.Drawing.Point(486, 318);
            this.readPendingTransactions.Margin = new System.Windows.Forms.Padding(2);
            this.readPendingTransactions.Name = "readPendingTransactions";
            this.readPendingTransactions.Size = new System.Drawing.Size(196, 25);
            this.readPendingTransactions.TabIndex = 18;
            this.readPendingTransactions.Text = "Read Pending Transactions";
            this.readPendingTransactions.UseVisualStyleBackColor = true;
            this.readPendingTransactions.Click += new System.EventHandler(this.PrintPendingTransactions_Click);
            // 
            // validate
            // 
            this.validate.Location = new System.Drawing.Point(486, 669);
            this.validate.Margin = new System.Windows.Forms.Padding(2);
            this.validate.Name = "validate";
            this.validate.Size = new System.Drawing.Size(196, 46);
            this.validate.TabIndex = 19;
            this.validate.Text = "Full Blockchain Validation";
            this.validate.UseVisualStyleBackColor = true;
            this.validate.Click += new System.EventHandler(this.Validate_Click);
            // 
            // checkBalance
            // 
            this.checkBalance.Location = new System.Drawing.Point(376, 692);
            this.checkBalance.Margin = new System.Windows.Forms.Padding(2);
            this.checkBalance.Name = "checkBalance";
            this.checkBalance.Size = new System.Drawing.Size(87, 24);
            this.checkBalance.TabIndex = 20;
            this.checkBalance.Text = "Check Balance";
            this.checkBalance.UseVisualStyleBackColor = true;
            this.checkBalance.Click += new System.EventHandler(this.CheckBalance_Click);
            // 
            // currentWalletLabel
            // 
            this.currentWalletLabel.AutoSize = true;
            this.currentWalletLabel.Location = new System.Drawing.Point(11, 645);
            this.currentWalletLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currentWalletLabel.Name = "currentWalletLabel";
            this.currentWalletLabel.Size = new System.Drawing.Size(74, 13);
            this.currentWalletLabel.TabIndex = 22;
            this.currentWalletLabel.Text = "Current Wallet";
            // 
            // transactionLabel
            // 
            this.transactionLabel.AutoSize = true;
            this.transactionLabel.Location = new System.Drawing.Point(483, 216);
            this.transactionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.transactionLabel.Name = "transactionLabel";
            this.transactionLabel.Size = new System.Drawing.Size(68, 13);
            this.transactionLabel.TabIndex = 23;
            this.transactionLabel.Text = "Transactions";
            // 
            // blocksLabel
            // 
            this.blocksLabel.AutoSize = true;
            this.blocksLabel.Location = new System.Drawing.Point(483, 46);
            this.blocksLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.blocksLabel.Name = "blocksLabel";
            this.blocksLabel.Size = new System.Drawing.Size(39, 13);
            this.blocksLabel.TabIndex = 24;
            this.blocksLabel.Text = "Blocks";
            // 
            // validationLabel
            // 
            this.validationLabel.AutoSize = true;
            this.validationLabel.Location = new System.Drawing.Point(489, 654);
            this.validationLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.validationLabel.Name = "validationLabel";
            this.validationLabel.Size = new System.Drawing.Size(53, 13);
            this.validationLabel.TabIndex = 25;
            this.validationLabel.Text = "Validation";
            // 
            // newBlockSingleThread
            // 
            this.newBlockSingleThread.Location = new System.Drawing.Point(485, 61);
            this.newBlockSingleThread.Margin = new System.Windows.Forms.Padding(2);
            this.newBlockSingleThread.Name = "newBlockSingleThread";
            this.newBlockSingleThread.Size = new System.Drawing.Size(197, 26);
            this.newBlockSingleThread.TabIndex = 26;
            this.newBlockSingleThread.Text = "Generate New Block (Single Thread)";
            this.newBlockSingleThread.UseVisualStyleBackColor = true;
            this.newBlockSingleThread.Click += new System.EventHandler(this.newBlockSingleThread_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(482, 383);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 27;
            // 
            // GreedyButton
            // 
            this.GreedyButton.AutoSize = true;
            this.GreedyButton.Checked = true;
            this.GreedyButton.Location = new System.Drawing.Point(31, 19);
            this.GreedyButton.Name = "GreedyButton";
            this.GreedyButton.Size = new System.Drawing.Size(59, 17);
            this.GreedyButton.TabIndex = 28;
            this.GreedyButton.TabStop = true;
            this.GreedyButton.Text = "Greedy";
            this.GreedyButton.UseVisualStyleBackColor = true;
            // 
            // AltruisticButton
            // 
            this.AltruisticButton.AutoSize = true;
            this.AltruisticButton.Location = new System.Drawing.Point(31, 42);
            this.AltruisticButton.Name = "AltruisticButton";
            this.AltruisticButton.Size = new System.Drawing.Size(64, 17);
            this.AltruisticButton.TabIndex = 29;
            this.AltruisticButton.TabStop = true;
            this.AltruisticButton.Text = "Altruistic";
            this.AltruisticButton.UseVisualStyleBackColor = true;
            // 
            // RandomButton
            // 
            this.RandomButton.AutoSize = true;
            this.RandomButton.Location = new System.Drawing.Point(31, 65);
            this.RandomButton.Name = "RandomButton";
            this.RandomButton.Size = new System.Drawing.Size(65, 17);
            this.RandomButton.TabIndex = 30;
            this.RandomButton.TabStop = true;
            this.RandomButton.Text = "Random";
            this.RandomButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GreedyButton);
            this.groupBox1.Controls.Add(this.AltruisticButton);
            this.groupBox1.Controls.Add(this.RandomButton);
            this.groupBox1.Location = new System.Drawing.Point(485, 406);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 94);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mining Mode";
            // 
            // BlockchainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(693, 726);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createTransaction);
            this.Controls.Add(this.newBlockSingleThread);
            this.Controls.Add(this.validationLabel);
            this.Controls.Add(this.blocksLabel);
            this.Controls.Add(this.transactionLabel);
            this.Controls.Add(this.currentWalletLabel);
            this.Controls.Add(this.checkBalance);
            this.Controls.Add(this.validate);
            this.Controls.Add(this.readPendingTransactions);
            this.Controls.Add(this.printBlockchain);
            this.Controls.Add(this.newBlockMultiThread);
            this.Controls.Add(this.reciever);
            this.Controls.Add(this.recieverKeyLabel);
            this.Controls.Add(this.fee);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.feeLabel);
            this.Controls.Add(this.amountLabel);
            this.Controls.Add(this.validateKeys);
            this.Controls.Add(this.privateKey);
            this.Controls.Add(this.publicKey);
            this.Controls.Add(this.privateKeyLabel);
            this.Controls.Add(this.publicKeyLabel);
            this.Controls.Add(this.generateWallet);
            this.Controls.Add(this.blockNo);
            this.Controls.Add(this.printBlock);
            this.Controls.Add(this.output);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "BlockchainApp";
            this.Text = "Blockchain App";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox output;
        private System.Windows.Forms.Button printBlock;
        private System.Windows.Forms.TextBox blockNo;
        private System.Windows.Forms.Button generateWallet;
        private System.Windows.Forms.Label publicKeyLabel;
        private System.Windows.Forms.Label privateKeyLabel;
        private System.Windows.Forms.TextBox publicKey;
        private System.Windows.Forms.TextBox privateKey;
        private System.Windows.Forms.Button validateKeys;
        private System.Windows.Forms.Button createTransaction;
        private System.Windows.Forms.TextBox fee;
        private System.Windows.Forms.TextBox amount;
        private System.Windows.Forms.Label feeLabel;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.TextBox reciever;
        private System.Windows.Forms.Label recieverKeyLabel;
        private System.Windows.Forms.Button newBlockMultiThread;
        private System.Windows.Forms.Button printBlockchain;
        private System.Windows.Forms.Button readPendingTransactions;
        private System.Windows.Forms.Button validate;
        private System.Windows.Forms.Button checkBalance;
        private System.Windows.Forms.Label currentWalletLabel;
        private System.Windows.Forms.Label transactionLabel;
        private System.Windows.Forms.Label blocksLabel;
        private System.Windows.Forms.Label validationLabel;
        private System.Windows.Forms.Button newBlockSingleThread;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton GreedyButton;
        private System.Windows.Forms.RadioButton AltruisticButton;
        private System.Windows.Forms.RadioButton RandomButton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

