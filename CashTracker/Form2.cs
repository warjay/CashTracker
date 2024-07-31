using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CashTracker
{
    public partial class Form2 : Form
    {
        public string Title { get; private set; }
        public string Desc { get; private set; }
        public decimal Amount { get; private set; }
        public string Notes { get; private set; }
        public Form2(string Title,string Desc,decimal Amount,string Notes)
        {
            InitializeComponent();
            textBox1.Text = Title;
            textBox2.Text = Desc;
            numericUpDown1.Value = Amount;
            richTextBox1.Text = Notes;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Title = textBox1.Text;
            Desc = textBox2.Text;
            Amount = numericUpDown1.Value;
            Notes = richTextBox1.Text;

            if (string.IsNullOrWhiteSpace(Name))
            {
                MessageBox.Show("Please enter name of entry at minimum.", "Entry Creation Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
