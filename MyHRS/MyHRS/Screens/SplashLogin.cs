using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using MyHRS.Classes;
using System.IO;

namespace MyHRS.Screens
{
    public partial class SplashLogin : Form
    {
        string AccessCode = "ZHRMIS";
        string SystemCode = "ZHRMIS";

        clsYU YU = new clsYU();
        bool isLogin = false;

        public SplashLogin()
        {
            InitializeComponent();
        }

        #region UI
        private void TextboxControl()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.GetType().Name == "GroupBox")
                {
                    foreach (Control GBCtrl in ctrl.Controls)
                    {
                        if (GBCtrl.GetType().Name == "Panel")
                        {
                            foreach (Control PnlCtrl in GBCtrl.Controls)
                            {
                                if (PnlCtrl.GetType().Name == "TextBox")
                                {
                                    TextBox tb = (TextBox)PnlCtrl;
                                    tb.Enter += new EventHandler(tb_Enter);
                                    tb.Leave += new EventHandler(tb_Leave);
                                }
                            }
                        }
                    }
                }
            }
        }
        private void LoadLoginBG()
        {
            try
            {
                PBSplashImage.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\Resources\\LoginPIC.jpg");
                PBSplashImage.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch(Exception ex)
            {
                YU.LogWrite(ex.Message.ToString(),"SplashLogin", "Error");        
            }
        }
        #endregion


        public void ControlInitialized()
        {
           TextboxControl();
           LoadLoginBG();
        }

        private void SplashLogin_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "Initialization...";
            ControlInitialized();
            timer1.Enabled = true;
            YU.LogWrite("Start Program","SplashLogin", "Log");
        }

        private bool CheckAccessCode(ref string ACode)
        {
            bool result = false;
            try
            {
                string GetAccessCodeIni = YU.IniValue("AccessCode", "Codes");
                if (!string.IsNullOrEmpty(GetAccessCodeIni))
                {
                    ACode = AccessCode + "_" + YU.GetMachineID();
                    ACode = YU.GetEncryptWord(ACode);
                    if (GetAccessCodeIni == ACode)
                    {
                        result = true;
                    }
                }
            }
            catch
            {
            }
            return result;
        }

        private bool CheckMachineID(ref string MachineID)
        {
            bool result = false;
            try
            {
                MachineID = YU.GetMachineID();
                string INIMacID = string.Empty;
                if (!string.IsNullOrEmpty(MachineID))
                {
                    INIMacID = YU.IniValue("MachineID", "Codes");
                }
            }
            catch
            {
            }
            return result;
        }

        private bool CheckDatabase()
        {
            bool result = false;
            try
            {
                string ServerName = YU.IniValue("ServerName","DatabaseConnection");
                string DatabaseName = YU.IniValue("DatabaseName","DatabaseConnection");
                string Username = YU.IniValue("Username","DatabaseConnection");
                string Password = YU.IniValue("Password","DatabaseConnection");

                result = YU.CheckDatabaseConnection(ServerName, DatabaseName, Username, Password);

            }
            catch
            {

            }
            return result;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblStatus.Visible = true;            
            progressBar1.Value += 10;
            if (progressBar1.Value == 20)
            {
                Thread.Sleep(100);
                lblStatus.Text = "Checking Database...";
                timer1.Enabled = false;
                YU.LogWrite("Trying to connect into database", "Database Connection", "Log");
                if (!CheckDatabase())
                {
                    MessageBox.Show("Error: Cannot connect to database. Check your connection", "Database failed to connect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    YU.LogWrite("Cannot connect to database","Database Connection","Error");
                    Environment.Exit(0);
                }
                timer1.Enabled = true;
            }
            if (progressBar1.Value == 50)
            {
                Thread.Sleep(100);
                lblStatus.Text = "Checking License...(MachineID)";
                timer1.Enabled = false;
                string MachineCode = string.Empty;
                YU.LogWrite("Matching MachineID :" + MachineCode, "Checking MachineID", "Log");
                if (!CheckMachineID(ref MachineCode))
                {
                    YU.LogWrite("Machine ID:" + MachineCode, "MachineID mismatch", "Error");
                   DialogResult dr = MessageBox.Show("Warning: Your Machine ID mismatch. Would you like to update your system using this ID\nMachineID : " + MachineCode, "MachineID", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    YU.LogWrite("MachineID Mismatch (" + MachineCode + ")" , "Invalid MachineID", "Error");
                    if (dr == System.Windows.Forms.DialogResult.Yes)
                    {
                        YU.WriteIniValue("MachineID", MachineCode, "Codes");
                        YU.LogWrite("Registered Machine ID:" + MachineCode, "Checking MachineID Done", "Log");
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
                timer1.Enabled = true;
            }
            if (progressBar1.Value == 70)
            {
                Thread.Sleep(100);
                lblStatus.Text = "Checking License...(Access Code)";
                timer1.Enabled = false;
                string AccessCode = string.Empty;
                YU.LogWrite("Matching AccessCode :" + AccessCode, "Checking AccessCode", "Log");
                if (!CheckAccessCode(ref AccessCode))
                {
                    YU.LogWrite("Access Code:" + AccessCode, "AccessCode invalid", "Error");
                    MessageBox.Show("Error: Unable to start the program. Please contact your software vendor.\nAccessCode : " + AccessCode, "AccessCode Invalid", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
                YU.LogWrite("Registered Access Code:" + AccessCode, "Checking AccessCode Done", "Log");
                timer1.Enabled = true;
            }
            if (progressBar1.Value == 80)
            {   
                Thread.Sleep(100);
                lblStatus.Text = "Checking License...(Serial Key)";
                timer1.Enabled = false;
                string SerialKey = string.Empty;
                int daysRemain = 0;
                if (!YU.isValidLicense(ref SerialKey,SystemCode,ref daysRemain))
                {
                    if (YU.CheckEvalFile(false))
                    {
                        DialogResult dr = MessageBox.Show("Warning: Your Serial Key is Invalid. Would you like to use the system in Evaluation Mode for [60 days]?", "Evaluation Copy", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == System.Windows.Forms.DialogResult.No)
                        {
                            Environment.Exit(0);
                        }
                        else
                        {
                            string w_file = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".exe";
                            string w_directory = Directory.GetCurrentDirectory();

                            DateTime c3 = File.GetLastWriteTime(System.IO.Path.Combine(w_directory, w_file));
                            DateTime NewDate = c3.AddDays(60);

                            string NewSerialKey = AccessCode + "_" + c3.ToShortDateString() + "_" + NewDate.ToShortDateString();
                            YU.WriteIniValue("SerialKey", YU.GetEncryptWord(NewSerialKey), "Codes");
                            daysRemain = NewDate.Subtract(c3).Days;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error: You have used the evaluation copy of this software. Contact vendor to have the full version of this system.", "Evaluation Copy Ends", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Environment.Exit(0);
                    }
                }

                YU.LogWrite("Serial Key:" + SerialKey, "SerialKey Invalid", "Error");
                if (daysRemain <= 0)
                {
                    MessageBox.Show("Error: License Expired. Please contact your vendor.", "System Close: License Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Environment.Exit(0);
                }
                if (daysRemain < 30)
                {
                    MessageBox.Show("Warning: You only have " + daysRemain + " days to use the application. Please contact your vendor before it ends.", "Evaluation Period Near to Expire", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                timer1.Enabled = true;
            }
            if (progressBar1.Value == 100)
            {
                Thread.Sleep(100);
                timer1.Enabled = false;
                this.Height = 315;
                lblStatus.Visible = false;
            }
           
        }

        private void tb_Enter(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.BackColor = Color.Yellow;
        }

        private void tb_Leave(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.BackColor = Color.White;
        }

        private void textBox2_MouseHover(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '\0';
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Error: Invalid entry. Please check", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                YU.Control_TextboxError(textBox1);
                textBox1.Focus();
            }
            isLogin = true;
            this.Close();
        }

        private void SplashLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isLogin)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to close this program?", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }

        private void databaseConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatabaseConnection dc = new DatabaseConnection();
            dc.ShowDialog();
        }

    }
}
