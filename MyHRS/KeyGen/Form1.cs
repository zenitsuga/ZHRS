using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;

namespace KeyGen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string GetMachineID()
        {
            string result = string.Empty;
            try
            {
                ManagementClass mc = new ManagementClass("win32_processor");
                ManagementObjectCollection moc = mc.GetInstances();

                foreach (ManagementObject mo in moc)
                {
                    if (result == "")
                    {
                        //Get only the first CPU's ID
                        result = mo.Properties["processorID"].Value.ToString();
                        break;
                    }
                }
                return result;
            }
            catch
            {
            }
            return result;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = GetMachineID(); 
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                textBox4.Enabled = true;
                textBox4.Text = "0";
                radioButton2.Checked = false;
                dateTimePicker1.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                textBox4.Enabled = false;
                textBox4.Text = "0";
                radioButton1.Checked = false;
                dateTimePicker1.Enabled = true;
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.KeyValue > 48 && e.KeyValue < 57) && e.KeyValue != 8)
            {
                MessageBox.Show("Enter Number only", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Text = string.Empty;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if(textBox4.Text == "0")
            textBox4.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty || textBox3.Text == string.Empty)
            {
                MessageBox.Show("Error: Blank Field Found. Please check your configuration settings(.ini)", "Error Generating", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == string.Empty)
            {
                textBox4.Text = "0";
            }
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            listView1.Items.Add(e.Data.ToString());
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
    }
}
