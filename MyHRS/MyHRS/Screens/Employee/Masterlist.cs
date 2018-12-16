using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using MyHRS.Classes;

namespace MyHRS.Screens.Employee
{
    public partial class Masterlist : Form
    {
        public SqlConnection Sconn;
        DataTable dtApplicantList;
        DataView dvRecords;

        clsFunctions cf = new clsFunctions();

        public Masterlist()
        {
            InitializeComponent();
        }

        private void Masterlist_Load(object sender, EventArgs e)
        {
            cf.SQLConn = Sconn;
            LoadCombos();
            dtApplicantList = new DataTable();
            dtApplicantList = cf.dtGetApplicantlist(0);
        }

        private void LoadCombos()
        {
            cmbApplicationStatus.DataSource = cf.dtGetApplicantStatus();
            cmbApplicationStatus.DisplayMember = "name";
            cmbApplicationStatus.ValueMember = "id";


            cmbEmployeeStatus.DataSource = cf.dtGetEmployeeStatus();
            cmbEmployeeStatus.DisplayMember = "name";
            cmbEmployeeStatus.ValueMember = "id";
        }

        private void cmbApplicationStatus_SelectedValueChanged(object sender, EventArgs e)
        {
            if (dtApplicantList == null)
            {
                return;
            }
            if (dtApplicantList.Rows.Count > 0)
            {
                dvRecords = new DataView(dtApplicantList);
                dvRecords.RowFilter = "[Application Status]='" + cmbApplicationStatus.Text.ToString() + "'";
                if (dvRecords.ToTable().Rows.Count > 0)
                {
                    dataGridView1.DataSource = dvRecords.ToTable();
                }
                else
                {
                    MessageBox.Show("No Record Found for Status: " + cmbApplicationStatus.Text.ToString(), "No record found, Load Default list", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dvRecords.RowFilter = null;
                    dataGridView1.DataSource = dtApplicantList;
                }
            }
        }

        private void GetRecords(string AppStatus)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Error: Please select applicant to accept in the list first.", "No Selected Applicant", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dr = MessageBox.Show("Are you sure you want to apply Employee status on selected lists?", "Apply \"" + cmbEmployeeStatus.Text.ToString() + "\" to selected list?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                foreach (DataGridViewRow dgr in dataGridView1.SelectedRows)
                {

                }
            }
        }
    }
}
