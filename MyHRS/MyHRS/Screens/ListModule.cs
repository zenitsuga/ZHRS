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

namespace MyHRS.Screens
{
    public partial class ListModule : Form
    {
        clsFunctions cf = new clsFunctions();

        public SqlConnection Sconn;
        public string tableName;
        public string columnName;
        public string Criteria;
        public string Sort;
        public string SQLQuery;

        public ListModule()
        {
            InitializeComponent();
        }

        private void ListModule_Load(object sender, EventArgs e)
        {
            try
            {
                SQLQuery = "Select " + columnName + " from " + tableName + " " + (string.IsNullOrEmpty(Criteria) ? string.Empty : " where ") + Criteria + " " + (string.IsNullOrEmpty(Sort) ? string.Empty : " order by ") + Sort;
                DataTable dtResult = new DataTable();
                
                cf.SQLConn = Sconn;
                dtResult = cf.dtGetSelectRecord("sp_executesql", SQLQuery);
                dataGridView1.DataSource = dtResult;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message.ToString(), "Error in Query", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
