using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BlockchainAssignment
{
    public partial class BlockchainApp : Form
    {
        /* Global Blockchain object - Our working blockchain */
        Blockchain blockchain;

        /* Initialize blockchain on startup of application UI */
        public BlockchainApp()
        {
            InitializeComponent();
            blockchain = new Blockchain();
            richTextBox1.Text = "New blockchain initialised!";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        // Duplicate the value input into our new textbox (textBox1) in the large "console" (richTextBox1)
        private void button1_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(blockIndex.Text, out int index))
                richTextBox1.Text = blockchain.getBlockAsString(index);
            else
                richTextBox1.Text = "Please enter a valid number";

        }
    }
}
