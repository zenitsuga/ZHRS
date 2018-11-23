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
    public partial class Applicant_Masterlist : Form
    {
        public string RecordType;

        public SqlConnection SConn;

        clsFunctions cf = new clsFunctions();

        public string[] ColumnApplicant = new string[] {"id","Lastname","Firstname","Firstname","middlename","birth_place"};
        public string[] ColumnDates = new string[] {"application_date","date_created","date_modified","birth_date","marriage_date"};

        string Record_Query = string.Empty;

        public Applicant_Masterlist()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                dtpickEnd.Enabled = false;
                dtpickStart.Enabled = false;
                cmbColumLists.Enabled = false;
                tbSearchWord.Text = tbContentBy.Text = string.Empty;
                tbSearchWord.ReadOnly = false;
                tbContentBy.ReadOnly = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                dtpickEnd.Enabled = false;
                dtpickStart.Enabled = false;
                cmbDates.Enabled = false;
                cmbColumLists.Enabled = true;
                tbSearchWord.Text = tbContentBy.Text = string.Empty;
                tbContentBy.ReadOnly = false;
                tbSearchWord.ReadOnly = true;
            }
        }

        private void Applicant_Masterlist_Load(object sender, EventArgs e)
        {
            cf.SQLConn = SConn;
            cf.TextboxEvent(this);
            LoadCombo(cmbColumLists);
            LoadCombo(cmbDates);
            if (string.IsNullOrEmpty(RecordType) || RecordType == "Applicant")
            {
                Record_Query = "exec sp_GetApplicantList ''";
            }
            else
            {
                Record_Query = "exec sp_GetEmployeeList ''";
            }
            LoadRecord();
        }
        private void LoadRecord()
        {
            try
            {
                DataTable dtResult = cf.dtGetSelectRecords(Record_Query);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dtResult;
                dataGridView1.Refresh();
                tssTotalRecord.Text = dataGridView1.Rows.Count.ToString();
            }
            catch
            {
            }
        }
        private void LoadCombo(ComboBox cmb)
        {
            try
            {
                if (cmb.Name == "cmbColumLists")
                {
                    cmb.Items.Clear();
                    foreach (string strCLists in ColumnApplicant)
                    {
                        cmb.Items.Add(strCLists);
                    }
                }
                else if (cmb.Name == "cmbDates")
                {
                    cmb.Items.Clear();
                    foreach (string strDates in ColumnDates)
                    {
                        cmb.Items.Add(strDates);
                    }
                }
            }
            catch
            {
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                dtpickEnd.Enabled = false;
                dtpickStart.Enabled = false;
                cmbDates.Enabled = false;
                cmbColumLists.Enabled = false;
                tbSearchWord.Text = tbContentBy.Text = string.Empty;
                tbContentBy.ReadOnly = true;
                tbSearchWord.ReadOnly = true;
                Record_Query = "exec sp_GetApplicantList 'All'";
                LoadRecord();
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                dtpickEnd.Enabled = true;
                dtpickStart.Enabled = true;
                cmbDates.Enabled = true;
                cmbColumLists.Enabled = false;
                tbContentBy.ReadOnly = true;
                tbSearchWord.ReadOnly = true;
                tbContentBy.Text = tbSearchWord.Text = string.Empty;
            }
        }
    }
}
