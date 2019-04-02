using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemB
{
    public partial class Form1 : Form
    {
        //City
        //id
        //nazev
        // koordinaty

        PrefixTree<int> prefixTree = new PrefixTree<int>();
        int i = 1;

        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //            openFileDialog1.ShowDialog();
            //          button1.Text = openFileDialog1.FileName;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.Text = openFileDialog1.FileName;
                try
                {
                    // var sr = new StreamReader(openFileDialog1.FileName);
                    using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                    {

                        string line;
                        // Read and display lines from the file until the end of 
                        // the file is reached.
                        while ((line = sr.ReadLine()) != null)
                        {
                            prefixTree.AddValue(line, i++);
                        }
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            labelInfo.Text = prefixTree.Find(textBoxInputData.Text).ToString();
            int index = prefixTree.Find(textBoxInputData.Text);
            if (index == 0)
            {
                labelInfo.Text = "Place not found";
            }
            else
            {
                labelInfo.Text = index.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBoxInputData.Text.Length != 0)
            {
                if (prefixTree.AddValue(textBoxInputData.Text, i++))
                {
                    labelInfo.Text = "Record has been added";
                }
                else
                {
                    labelInfo.Text = "Record already exists";
                }
            }
            else
            {
                labelInfo.Text = "Please enter place to the form";
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (textBoxInputData.Text.Length != 0)
            {
                if (prefixTree.Remove(textBoxInputData.Text))
                {
                    labelInfo.Text = "Record has been removed";
                }
                else
                {
                    labelInfo.Text = "Record does not exist";
                }
            }
            else
            {
                labelInfo.Text = "Please enter place to the form";
            }
        }
    }


}
