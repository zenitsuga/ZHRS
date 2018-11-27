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

namespace MyHRS.Screens
{
    public partial class SearchRecord : Form
    {
        clsFunctions cf = new clsFunctions();
        public SqlConnection Sconn;
        public DataTable dtRecords;
        public DataView dvrecords;
        public int SelectedID;

        public SearchRecord()
        {
            InitializeComponent();
        }

        private void SearchRecord_Load(object sender, EventArgs e)
        {
            cf.SQLConn = Sconn;
            dtRecords = new DataTable();
            dtRecords = cf.dtGetApplicantlist(0);
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.ToLower().Contains("show"))
            {
                dvrecords = new DataView(dtRecords);
                if (dvrecords.ToTable().Rows.Count > 0)
                {
                    dataGridView1.DataSource = dvrecords.ToTable();
                }
                else if (dtRecords.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dtRecords;
                }
                tssTotalRecord.Text = dataGridView1.Rows.Count.ToString();
            }
         }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!comboBox1.Text.ToLower().Contains("show"))
                {
                    if (dtRecords.Rows.Count > 0)
                    {
                        dvrecords = new DataView(dtRecords);
                        dvrecords.RowFilter = comboBox1.Text + "='" + textBox1.Text + "'";
                    }
                    dataGridView1.DataSource = dvrecords.ToTable();
                    tssTotalRecord.Text = dataGridView1.Rows.Count.ToString();
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRow();
        }
        private void SelectedRow()
        {
            SelectedID = cf.isInteger(dataGridView1.SelectedRows[0].Cells["id"].Value.ToString()) ? int.Parse(dataGridView1.SelectedRows[0].Cells["id"].Value.ToString()) : 0;
            string Name = (string.IsNullOrEmpty(dataGridView1.SelectedRows[0].Cells["lastname"].Value.ToString()) ? string.Empty : dataGridView1.SelectedRows[0].Cells["lastname"].Value.ToString() + ",") + (string.IsNullOrEmpty(dataGridView1.SelectedRows[0].Cells["Firstname"].Value.ToString()) ? string.Empty : dataGridView1.SelectedRows[0].Cells["Firstname"].Value.ToString() + " ") + (string.IsNullOrEmpty(dataGridView1.SelectedRows[0].Cells["middlename"].Value.ToString()) ? string.Empty : dataGridView1.SelectedRows[0].Cells["middlename"].Value.ToString().Substring(0, 1));
            DialogResult dr = MessageBox.Show("Are you sure you want to load the details of this record?", "Load Details : " + Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectedRow();
            }
        }
    }
}
