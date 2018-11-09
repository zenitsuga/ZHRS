using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ZHKrypTon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Initialized()
        {
            if (File.Exists(Environment.CurrentDirectory + "\\Resources\\BG.PNG"))
            {
                this.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\Resources\\BG.PNG");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Initialized();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Error: Please enter a key first.", "No value Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }
            if (radioButton1.Checked)
            {
                textBox2.Text = Licensing.CryptoEngine.Encrypt(textBox1.Text, Licensing.CryptoEngine.Key());
            }
            else
            {
                textBox2.Text = Licensing.CryptoEngine.Decrypt(textBox1.Text, Licensing.CryptoEngine.Key());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           if(string.IsNullOrEmpty(textBox2.Text))
           {
               MessageBox.Show("Error: No value to copy. Please check your field.","Value not found",MessageBoxButtons.OK,MessageBoxIcon.Error);
               return;
           }
           Clipboard.SetText(textBox2.Text);
               MessageBox.Show("Value copied to clipboard.","Save to Clipboard",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
