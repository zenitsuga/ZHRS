using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MyHRS.Screens.Recruitment
{
    public partial class Interview_Management : Form
    {
        public SqlConnection Sconn;

        public Interview_Management()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListModule lm = new ListModule();
            lm.Sconn = Sconn;
            lm.tableName = "";
            lm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListModule lm = new ListModule();
            lm.ShowDialog();
        }
    }
}
