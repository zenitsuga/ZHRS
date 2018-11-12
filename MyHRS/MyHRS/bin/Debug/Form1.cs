using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyHRS.Screens;
using MyHRS.Screens.Recruitment;

namespace MyHRS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //SplashLogin sp = new SplashLogin();
            //sp.ShowDialog();
        }

        private void databaseConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatabaseConnection dc = new DatabaseConnection();
            dc.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ApplicantProfile ap = new ApplicantProfile();
            ap.MdiParent = this;
            ap.Top = 0;
            ap.Left = 0;
            ap.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Interview_Management im = new Interview_Management();
            im.MdiParent = this;            
            im.StartPosition = FormStartPosition.Manual;
            im.Top = 0;
            im.Left = 0;
            im.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HiringProcess hp = new HiringProcess();
            hp.MdiParent = this;
            hp.StartPosition = FormStartPosition.Manual;
            hp.Top = 0;
            hp.Left = 0;
            hp.Show();
        }
    }
}
