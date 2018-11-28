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
using System.Threading;

namespace MyHRS.Screens.Recruitment
{
    public partial class HiringProcess : Form
    {
        public SqlConnection Sconn;

        clsFunctions cf = new clsFunctions();

        DataTable dtRecords = new DataTable();
        DataView dvApplicantList;
        DataView dvAppList;
        DataTable dtRecordHiringList;

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
            cf.TextboxEvent(this);
            cf.clearTextboxEvent(this);
            dtRecordHiringList = new DataTable();
            ConstructMyDtHiringList();
            LoadApplicant();
            LoadApplicantStatus();
            dgvHiringList.DataSource = dtRecordHiringList;
        }
        private void ConstructMyDtHiringList()
        {
            try
            {
                if (dtRecordHiringList.Columns.Count > 0)
                {
                    dtRecordHiringList.Columns.Clear();
                }
                if (dtRecordHiringList.Rows.Count > 0)
                {
                    dtRecordHiringList.Rows.Clear();
                }
                DataColumn dcIsChecked = new DataColumn("Checked",typeof(bool));
                dtRecordHiringList.Columns.Add(dcIsChecked);
                DataColumn dcID = new DataColumn("ID", typeof(int));
                dtRecordHiringList.Columns.Add(dcID);
                DataColumn dcApplicantName = new DataColumn("Applicant Name", typeof(string));
                dtRecordHiringList.Columns.Add(dcApplicantName);
                DataColumn dcApplicantStatus = new DataColumn("Applicant Status", typeof(string));
                dtRecordHiringList.Columns.Add(dcApplicantStatus);
            }
            catch
            {
            }
        }
        private void LoadApplicantStatus()
        {
            try
            {
                #region Applicant Status
                string LAST_SP_Name = "sp_GetApplicant_Status";
                cmbApplicantStatus.DataSource = cf.dtGetSelectRecord(LAST_SP_Name);
                cmbApplicantStatus.ValueMember = "code";
                cmbApplicantStatus.DisplayMember = "Name";
                #endregion
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
                    DataColumn dcApplicantStatus = new DataColumn("Application Status");
                    dtApplicantInformation.Clear();
                    dtApplicantInformation.Columns.Add(dcAppID);
                    dtApplicantInformation.Columns.Add(dcApplicantName);
                    dtApplicantInformation.Columns.Add(dcApplicantStatus);

                    foreach(DataRow drApp in dtApplicantRecords.Rows)
                    {
                        DataRow dr = dtApplicantInformation.NewRow();
                        dr["id"] = drApp["id"].ToString();
                        dr["Name"] = drApp["Lastname"].ToString() + (!string.IsNullOrEmpty(drApp["FirstName"].ToString()) ? "," + drApp["FirstName"].ToString() : string.Empty) + (!string.IsNullOrEmpty(drApp["MiddleName"].ToString()) ? " " + drApp["MiddleName"].ToString() : string.Empty);
                        dr["Application Status"] = drApp["Application Status"].ToString();
                        dtApplicantInformation.Rows.Add(dr);
                    }

                    dvApplicantList = new DataView(dtApplicantRecords);
                    dvAppList = new DataView(dtApplicantInformation);
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
            //tbEmpStatus.Text = cmbEmpStatus.Text;
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Ignore if a column or row header is clicked
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    DataGridViewCell clickedCell = (sender as DataGridView).Rows[e.RowIndex].Cells[e.ColumnIndex];

                    // Here you can do whatever you want with the cell
                    this.dataGridView1.CurrentCell = clickedCell;  // Select the clicked cell, for instance

                    // Get mouse position relative to the vehicles grid
                    var relativeMousePosition = dataGridView1.PointToClient(Cursor.Position);

                    // Show the context menu
                    this.cmsList.Show(dataGridView1, relativeMousePosition);
                }
            }
        }

        private void addToListToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
               DialogResult dr = MessageBox.Show("Are you sure you want to add this record to Hiring List?", "Add to Hiring List", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

              if (dr == DialogResult.Yes)
              {
                  foreach(DataGridViewRow dgr in dataGridView1.SelectedRows)
                  {
                      int id = cf.isInteger(dgr.Cells["id"].Value.ToString()) ? int.Parse(dgr.Cells["id"].Value.ToString()):0;
                      if (id > 0)
                      {
                          DataRow drHL = dtRecordHiringList.NewRow();
                          drHL["Checked"] = true;
                          drHL["id"] = id;
                          drHL["Applicant Name"] = dgr.Cells["Name"].Value.ToString();
                          drHL["Applicant Status"] = dgr.Cells["Application Status"].Value.ToString();

                          DataRow[] foundRow = dtRecordHiringList.Select("id=" + id);
                          if (foundRow.Count() == 0)
                          {
                              dtRecordHiringList.Rows.Add(drHL);
                          }
                      }
                  }
                  if (dtRecordHiringList.Rows.Count > 0)
                  {
                      dgvHiringList.DataSource = dtRecordHiringList;
                      dgvHiringList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                  }
              }
            }
        }

        private void addToListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadApplicant();
        }

        private void dgvHiringList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (dgvHiringList[e.ColumnIndex, e.RowIndex].Value.ToString().ToLower() == "true")
                {
                    dgvHiringList[e.ColumnIndex, e.RowIndex].Value = false;
                }
                else
                {
                    dgvHiringList[e.ColumnIndex, e.RowIndex].Value = true;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
                foreach (DataGridViewRow dgr in dgvHiringList.Rows)
                {
                    dgr.Cells[0].Value = checkBox1.Checked;
                }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Status = string.IsNullOrEmpty(cmbApplicantStatus.SelectedValue.ToString()) ? string.Empty:cmbApplicantStatus.SelectedValue.ToString();
            DialogResult dr = MessageBox.Show("Are you sure you want to apply this status to the list?", "Confirm Status " + Status, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int counterCheck = 0;

                foreach (DataGridViewRow dgr in dgvHiringList.Rows)
                {
                    if (dgr.Cells[0].Value.ToString() == "True")
                    {
                        counterCheck++;
                    }
                }

                double MaxCheckRecord = counterCheck;
                double intCounter = 1;

                foreach (DataGridViewRow dgr in dgvHiringList.Rows)
                {
                    Thread.Sleep(100);
                    if (dgr.Cells[0].Value.ToString() == "True")
                    {
                        progressBar1.Value = int.Parse((Math.Round((intCounter/ MaxCheckRecord),2) * 100).ToString());
                        string ID = dgr.Cells["id"].Value.ToString();
                        string IntAppStatus = cmbApplicantStatus.SelectedIndex.ToString();
                        string Query = "exec sp_UpdateApplicantStatus "+ ID +"," + (int.Parse(IntAppStatus) + 1);
                        lblProgressStatus.Text = "Applying " + cmbApplicantStatus.SelectedText.ToString() + " to ID:" + ID;
                        if (cf.executeSP(Query))
                        {
                            lblProgressStatus.Text = "Done";
                        }
                        intCounter++;
                    }
                    lblProgressStatus.Text = "Ready...";
                }
                dtRecordHiringList.Rows.Clear();
                dgvHiringList.DataSource = null;
                LoadApplicant();
                cf.TextboxEvent(this);
                cf.clearTextboxEvent(this);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {   
            if (dvAppList.ToTable().Rows.Count > 0)
            {
                dvAppList.RowFilter = "Name Like '" + textBox1.Text + "%'";
                //if (dvAppList.ToTable().Rows.Count == 0)
                //{
                //    dvAppList.RowFilter = "Firstname Like '" + textBox1.Text + "%'";
                //    if (dvAppList.ToTable().Rows.Count == 0)
                //    {
                //        dvAppList.RowFilter = "Middlename Like '" + textBox1.Text + "%'";
                //        if (dvAppList.ToTable().Rows.Count == 0)
                //        {
                //            dvAppList.RowFilter = null;
                //            LoadApplicant();
                //        }
                //    }
                //}
            }

            dataGridView1.DataSource = dvAppList.ToTable();
        }
    }
}
