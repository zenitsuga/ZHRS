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
using System.Data.SqlClient;
using MyHRS.Classes;

namespace MyHRS
{
    public partial class Form1 : Form
    {
        clsFunctions cf = new clsFunctions();        

        public SqlConnection Sconn;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SplashLogin sp = new SplashLogin();
            sp.ShowDialog();
            Sconn = sp.Sconn;
            tssEmployee.Visible = true;
            tssRecruitment.Visible = true;
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
            ap.WindowState = FormWindowState.Maximized;
            ap.Top = 0;
            ap.Left = 0;
            ap.Sconn = Sconn;
            if(cf.isChildFormLoaded(ap.Name))    
            ap.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Interview_Management im = new Interview_Management();
            im.MdiParent = this;            
            im.StartPosition = FormStartPosition.Manual;
            im.Top = 0;
            im.Left = 0;
            if (cf.isChildFormLoaded(im.Name))
            im.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HiringProcess hp = new HiringProcess();
            hp.MdiParent = this;
            hp.StartPosition = FormStartPosition.Manual;
            hp.Top = 0;
            hp.Left = 0;
            hp.Sconn = Sconn;
            if (cf.isChildFormLoaded(hp.Name))
            hp.Show();
        }

        private void sourcingAndApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplicantProfile ap = new ApplicantProfile();
            ap.MdiParent = this;
            ap.WindowState = FormWindowState.Maximized;
            ap.Top = 0;
            ap.Left = 0;
            ap.Sconn = Sconn;
            if (cf.isChildFormLoaded(ap.Name))
                ap.Show();
        }

        private void applicationScreeningAndInterviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Interview_Management im = new Interview_Management();
            im.MdiParent = this;
            im.StartPosition = FormStartPosition.Manual;
            im.Top = 0;
            im.Left = 0;
            if (cf.isChildFormLoaded(im.Name))
                im.Show();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            Applicant_Masterlist am = new Applicant_Masterlist();
            am.MdiParent = this;
            am.StartPosition = FormStartPosition.Manual;
            am.Top = 0;
            am.Left = 0;
            am.SConn = Sconn;
            if (cf.isChildFormLoaded(am.Name))
                am.Show();
        }

        private void masterlistsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Applicant_Masterlist am = new Applicant_Masterlist();
            am.MdiParent = this;
            am.StartPosition = FormStartPosition.Manual;
            am.Top = 0;
            am.Left = 0;
            am.SConn = Sconn;
            if (cf.isChildFormLoaded(am.Name))
                am.Show();
        }

        private void evaluationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HiringProcess hp = new HiringProcess();
            hp.MdiParent = this;
            hp.StartPosition = FormStartPosition.Manual;
            hp.Top = 0;
            hp.Left = 0;
            hp.Sconn = Sconn;
            if (cf.isChildFormLoaded(hp.Name))
                hp.Show();
        }
    }
}
