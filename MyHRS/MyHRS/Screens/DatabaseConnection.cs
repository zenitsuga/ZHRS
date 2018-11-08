using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyHRS.Classes;

namespace MyHRS.Screens
{
    public partial class DatabaseConnection : Form
    {
        clsYU yu = new clsYU();

        public DatabaseConnection()
        {
            InitializeComponent();
        }

        private void InitializedForm()
        {
            try
            {
                pbDBImage.Image = Image.FromFile(Environment.CurrentDirectory + "\\Resources\\Database.png");
                pbStopNGo.Image = Image.FromFile(Environment.CurrentDirectory + "\\Resources\\Stop.png");

                //Load Info from INI
                yu.LogWrite("Reading Ini File: DatabaseConnection", "DatabaseConnection", "Log");
                textBox1.Text = yu.IniValue("ServerName", "DatabaseConnection");
                textBox2.Text = yu.IniValue("Databasename", "DatabaseConnection");
                textBox3.Text = yu.IniValue("Username", "DatabaseConnection");
                textBox4.Text = yu.IniValue("Password", "DatabaseConnection");
            }
            catch(Exception ex)
            {
                yu.LogWrite(ex.Message.ToString(),"DatabaseConnection", "Error");        
            }
        }

        private void DatabaseConnection_Load(object sender, EventArgs e)
        {
            yu.LogWrite("Database Connection Open","DatabaseConnection", "Log");
            InitializedForm();
            CheckDB();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            yu.LogWrite("Trying to connect", "DatabaseConnection", "Log");
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty || textBox3.Text == string.Empty || textBox4.Text == string.Empty)
            {
                MessageBox.Show("Error: Cannot connect to database. Please check your creadential", "Database Connection failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                yu.LogWrite("Failed to connect", "DatabaseConnection", "Error");
                return;
            }

            CheckDB();
            
        }

        private void CheckDB()
        {
            if (!yu.CheckDatabaseConnection(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text))
            {
                pbStopNGo.Image = Image.FromFile(Environment.CurrentDirectory + "\\Resources\\Stop.png");
                MessageBox.Show("Error: Cannot connect to database. Please check your creadential", "Database Connection failed :" + textBox1.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                yu.LogWrite("Failed to connect :" + textBox1.Text, "DatabaseConnection", "Error");
                label1.Text = "DISCONNECTED";
                return;
            }
            else
            {
                MessageBox.Show("Database connection success.", "Database Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (yu.WriteIniValue("ServerName", textBox1.Text, "DatabaseConnection"))
                    if (yu.WriteIniValue("DatabaseName", textBox2.Text, "DatabaseConnection"))
                        if (yu.WriteIniValue("Username", textBox3.Text, "DatabaseConnection"))
                            yu.WriteIniValue("Password", textBox4.Text, "DatabaseConnection");
                pbStopNGo.Image = Image.FromFile(Environment.CurrentDirectory + "\\Resources\\Go.png");
                label1.Text = "CONNECTED";
            }
        }

        private void textBox4_MouseHover(object sender, EventArgs e)
        {
            textBox4.PasswordChar = '\0';
        }

        private void textBox4_MouseLeave(object sender, EventArgs e)
        {
            textBox4.PasswordChar = '*';
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void showTablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter Access code", "Access code required", "Default", -1, -1);
        }
    }
}
