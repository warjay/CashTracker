using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashTracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        void updateTotal()
        {
            decimal total = 0;
            foreach (ListViewItem i in listView1.Items)
            {
                total += decimal.Parse(i.SubItems[2].Text);
            }
            totalLabel.Text = $"Total: {total.ToString()}";
        }

        ListViewItem getEntryInput(ListViewItem old = null)
        {
            string Title = "";
            string Desc = "";
            decimal Amount = 0;
            string Notes = "";
            if (old != null)
            {
                // Unpack ListViewItem for parameters
                Title = old.Text;
                Desc = old.SubItems[1].Text;
                Amount = decimal.Parse(old.SubItems[2].Text);
                Notes = old.SubItems[3].Text;
            }
            // Create an instance of the LoginForm
            using (Form2 entryForm = new Form2(Title,Desc,Amount,Notes))
            {
                // Show create/edit form
                if (entryForm.ShowDialog() == DialogResult.OK)
                {
                    // Get Data
                    Title = entryForm.Title;
                    Desc = entryForm.Desc;
                    Amount = entryForm.Amount;
                    Notes = entryForm.Notes;

                    // Create Entry
                    ListViewItem entry = new ListViewItem(Title);
                    entry.SubItems.Add(Desc);
                    entry.SubItems.Add(Amount.ToString());
                    entry.SubItems.Add(Notes);
                    return entry;

                }
                else
                {
                    return null;
                }
            }
            
        }


        private void addBtn_Click(object sender, EventArgs e)
        {
            ListViewItem entry = getEntryInput();
            listView1.Items.Add(entry);

            // Update Main Form
            updateTotal();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                ListViewItem newEntry = getEntryInput(listView1.SelectedItems[0]);
                if (newEntry != null)
                {
                    listView1.Items[listView1.SelectedIndices[0]] = newEntry;
                }   
            }
            else
            {
                MessageBox.Show("Select An Entry (Only 1)", "Edit Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                foreach (ListViewItem i in listView1.SelectedItems)
                {
                    listView1.Items.Remove(i);
                }
            }
            else
            {
                MessageBox.Show("Select At Least 1 Entry To Delete", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
