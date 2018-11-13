using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyHRS.Classes;
using System.Data.SqlClient;

namespace MyHRS.Screens.Recruitment
{
    public partial class ApplicantProfile : Form
    {
        clsFunctions cf = new clsFunctions();

        public SqlConnection Sconn;

        public ApplicantProfile()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void PanelControl(Button btnPnl,Panel ModulePanel,int HeightMax)
        {
            if (btnPnl.Height != ModulePanel.Height)
            {
                ModulePanel.Height = btnPnl.Height;
            }
            else
            {
                ModulePanel.Height = HeightMax;
            }
        }

        private void btnPersonalProfile_Click(object sender, EventArgs e)
        {
            PanelControl(btn_Application, panel_Applicaation, 55);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnInterview_Click(object sender, EventArgs e)
        {
            Interview_Management im = new Interview_Management();
            im.ShowDialog();
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadAllCombos()
        {
            cf.SQLConn = Sconn;
            #region ID
            tb_ID.Text = "0";
            tb_ID.ReadOnly = true;
            #endregion
            #region Application_Status
            cmbApplicantStatus.DataSource = cf.dtGetApplicantStatus();
            cmbApplicantStatus.DisplayMember = "name";
            cmbApplicantStatus.ValueMember = "id";
            #endregion
            #region ApplicationType
            cmbApplicationType.DataSource = cf.dtGetApplicationType();
            cmbApplicationType.DisplayMember = "name";
            cmbApplicationType.ValueMember = "id";
            #endregion
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Educational_Background eb = new Educational_Background();
            eb.ShowDialog();
        }
        private void ApplicantProfile_Load(object sender, EventArgs e)
        {
            cf.ControlObjects(false,groupBox2);
            LoadAllCombos();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to create a new transaction?", "Create New Profile", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                tb_ID.Text = cf.GetNewID().ToString();
                cf.ControlObjects(true,groupBox2);
            }
        }

        private void btn_Interview_Click(object sender, EventArgs e)
        {
            PanelControl(btn_Interview, panel_Interview, 142);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PanelControl(btn_PersonalProfile, panel_Personal_Profile, 161);
        }

        private void btn_Address_Click(object sender, EventArgs e)
        {
            PanelControl(btn_Address, panel_Address, 148);
        }

        private void btn_Educational_Background_Click(object sender, EventArgs e)
        {
            PanelControl(btn_Educational_Background, panel_Education_Background, 151);
        }

        private void btn_Employment_Click(object sender, EventArgs e)
        {
            PanelControl(btn_Employment, panel_Employement_History, 150);
        }

        private void btn_Examination_Click(object sender, EventArgs e)
        {
            PanelControl(btn_Examination, panel_Examination, 162);
        }

        private void btn_Emergency_Click(object sender, EventArgs e)
        {
            PanelControl(btn_Emergency, panel_Emergency_Information, 124);
        }

        
    }
}
