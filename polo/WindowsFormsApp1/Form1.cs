using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
            textBox1.Text = "";
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add(textBox2.Text);
            textBox2.Text = "";
            textBox2.Focus();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                listBox1.Items.Add(textBox1.Text);
                textBox1.Text = "";
                textBox1.Focus();
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listBox2.Items.Add(textBox2.Text);
                textBox2.Text = "";
                textBox2.Focus();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                listBox2.Items.Add(listBox1.SelectedItem);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                listBox1.Items.Add(listBox2.SelectedItem);
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            }   
        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach (var item in listBox1.Items)
            {
                listBox2.Items.Add(item);
            }
            listBox1.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (var item in listBox2.Items)
            {
                listBox1.Items.Add(item);
            }
            listBox2.Items.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }
<<<<<<< HEAD
        
=======

        private void button8_Click(object sender, EventArgs e)
        {
            listBox2.Items.RemoveAt(listBox2.SelectedIndex);
        }
>>>>>>> 390d5d920775bf7a68df1edb2bb610abfbb92d26
    }
}
