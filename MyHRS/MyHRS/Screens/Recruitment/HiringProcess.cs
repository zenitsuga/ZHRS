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
    public partial class HiringProcess : Form
    {
        public SqlConnection Sconn;

        clsFunctions cf = new clsFunctions();

        DataTable dtRecords = new DataTable();
        DataView dvApplicantList;

        public HiringProcess()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if ((panelPersonalInfo.Height - 7) != btnPersonalInfo.Height)
            //{
            //    panelPersonalInfo.Height = btnPersonalInfo.Height + 7;
            //}
            //else
            //{
            //    panelPersonalInfo.Height = (panel1.Height - panelStatus.Height);
            //}
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            //if ((panelStatus.Height - 7) != btnStatus.Height)
            //{
            //    panelStatus.Height = btnStatus.Height + 7;
            //}
            //else
            //{
            //    panelStatus.Height = (panel1.Height - panelPersonalInfo.Height);
            //}
        }

        private void HiringProcess_Load(object sender, EventArgs e)
        {
            LoadApplicant();
            LoadEmployeeStatus();
        }
        private void LoadEmployeeStatus()
        {
            try
            {
                cmbEmpStatus.Items.Clear();
                cmbEmpStatus.DataSource = cf.dtGetSelectRecord("sp_GetEmployeeStatus");
                cmbEmpStatus.DisplayMember = "Name";
                cmbEmpStatus.ValueMember = "id";
            }
            catch
            {
            }
        }

        private void LoadApplicant()
        {
            try
            {
                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
                cf.SQLConn = Sconn;
                DataTable dtApplicantRecords = new DataTable();
                dtApplicantRecords = cf.dtGetApplicantlist(0);
                if(dtApplicantRecords.Rows.Count >0)
                {
                    DataTable dtApplicantInformation = new DataTable();
                    DataColumn dcAppID = new DataColumn("ID");
                    DataColumn dcApplicantName = new DataColumn("Name");
                    dtApplicantInformation.Clear();
                    dtApplicantInformation.Columns.Add(dcAppID);
                    dtApplicantInformation.Columns.Add(dcApplicantName);

                    foreach(DataRow drApp in dtApplicantRecords.Rows)
                    {
                        DataRow dr = dtApplicantInformation.NewRow();
                        dr["id"] = drApp["id"].ToString();
                        dr["Name"] = drApp["Lastname"].ToString() + (!string.IsNullOrEmpty(drApp["FirstName"].ToString()) ? "," + drApp["FirstName"].ToString() : string.Empty) + (!string.IsNullOrEmpty(drApp["MiddleName"].ToString()) ? " " + drApp["MiddleName"].ToString() : string.Empty);
                        dtApplicantInformation.Rows.Add(dr);
                    }
                
                    dvApplicantList = new DataView(dtApplicantRecords);
                    dataGridView1.DataSource = dtApplicantInformation;
                }
            }
            catch
            {
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          string ID = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();

          if (dvApplicantList.ToTable().Rows.Count > 0)
          {
              DataTable DvtoDtApplicantInfo = new DataTable();
              dvApplicantList.RowFilter = "id=" + ID;
              if (dvApplicantList.ToTable().Rows.Count == 1)
              {
                  DvtoDtApplicantInfo = dvApplicantList.ToTable();
                  tbFirstname.Text = DvtoDtApplicantInfo.Rows[0]["Firstname"].ToString();
                  tbLastname.Text = DvtoDtApplicantInfo.Rows[0]["Lastname"].ToString();
                  tbMiddlename.Text = DvtoDtApplicantInfo.Rows[0]["Middlename"].ToString();
                  tbSuffix.Text = DvtoDtApplicantInfo.Rows[0]["Suffix"].ToString();
                  tbEmailAdd.Text = DvtoDtApplicantInfo.Rows[0]["email_address"].ToString();
                  tbNationality.Text = DvtoDtApplicantInfo.Rows[0]["nationality"].ToString();
                  tbGender.Text = DvtoDtApplicantInfo.Rows[0]["gender"].ToString();
                  tbCivilStatus.Text = DvtoDtApplicantInfo.Rows[0]["CivilStatus"].ToString();
                  tbPresentAdd.Text = DvtoDtApplicantInfo.Rows[0]["Present Address"].ToString();
                  tbPermanentAddress.Text = DvtoDtApplicantInfo.Rows[0]["Permanent Address"].ToString();
                  tbApplicationDate.Text = DvtoDtApplicantInfo.Rows[0]["Application_Date"].ToString();
                  tbApplicationStatus.Text = DvtoDtApplicantInfo.Rows[0]["Application Status"].ToString();
                  tbApplicationType.Text = DvtoDtApplicantInfo.Rows[0]["Application Type"].ToString();
              }
          }else
          {
              dvApplicantList.RowFilter = null;
          }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            tbEmpStatus.Text = cmbEmpStatus.Text;
        }
    }
}
