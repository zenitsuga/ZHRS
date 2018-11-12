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
using System.Text.RegularExpressions;

namespace MyHRS.Screens
{
    public partial class DatabaseViewer : Form
    {
        clsYU YU = new clsYU();

        public SqlConnection sqlconn;

        public DatabaseViewer()
        {
            InitializeComponent();
        }

        private void LoadTables()
        {
            try
            {
                string Query = "SELECT Table_Name FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' order by table_name asc";

                DataTable dtTables = YU.GetDTRecords(Query, sqlconn);
                if (dtTables.Rows.Count > 0)
                {
                    treeView1.Nodes.Clear();
                    TreeNode tn = new TreeNode();
                    tn.Tag = "Database";
                    tn.ImageIndex = 0;
                    tn.Text = sqlconn.Database.ToString();
                    int counterID = 0;
                    foreach (DataRow dr in dtTables.Rows)
                    {
                        counterID++;
                        TreeNode childNode = new TreeNode();
                        childNode.Tag = dr["Table_Name"].ToString();
                        childNode.Text = dr["Table_Name"].ToString();
                        childNode.SelectedImageIndex = 1;
                        childNode.ImageIndex = 1;
                        tn.Nodes.Add(childNode);
                    }
                    treeView1.Nodes.Add(tn);
                }
            }
            catch
            {
            }
        }

        private void DatabaseViewer_Load(object sender, EventArgs e)
        {
            if (sqlconn != null)
            {
                if (sqlconn.State == ConnectionState.Closed)
                {
                    sqlconn.Open();
                }
            }
            else
            {
                MessageBox.Show("Database connection not initialized. Please check your connection", "Connection Failed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            LoadTables();
        }

        private void DatabaseViewer_Resize(object sender, EventArgs e)
        {
            groupBox2.Left = groupBox1.Width + 10;
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            LoadTableDetails(e.Node);
        }
        private void LoadTableDetails(TreeNode tn)
        {
            try
            {
                if (tn.Tag.ToString() != "Database")
                {
                    string TableName = tn.Tag.ToString();

                    DataTable dtResult = new DataTable();
                    string Query = "Select * from " + TableName;
                    dtResult = YU.GetDTRecords(Query, sqlconn);
                    PopulateDatagridview(dtResult);
                }
            }
            catch
            {
            }
        }
        private void PopulateDatagridview(DataTable dtResult)
        {
            try
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dtResult;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString(), "Unexception Message: Contact your provider", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LoadTableDetails(e.Node);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Error: Field is empty. Please check your statement.", "Unable to execute command.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                    return;
                }

                DataTable dtResult = new DataTable();

                string SelectQuery = textBox1.Text;

                string GetTableName = string.Empty;

                if (SelectQuery.ToLower().Contains(" from ") && SelectQuery.ToLower().Contains("select"))
                {
                    dtResult = YU.GetDTRecords(SelectQuery, sqlconn);
                }
                else
                {
                    if (SelectQuery.ToLower().Contains(" into "))
                    {
                        GetTableName = Regex.Match(SelectQuery, @"\sinto\s(\w+)\s", RegexOptions.IgnoreCase).Groups[1].Value.ToString();
                    }
                    dtResult = YU.GetDTRecords("Select * from " + GetTableName, sqlconn);
                }
                dataGridView1.DataSource = dtResult;
                
            }
            catch
            {
            }
        }
    }
}
