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

namespace MyHRS.Screens.Recruitment
{
    public partial class ApplicantEvaluation : Form
    {
        clsFunctions cf = new clsFunctions();

        public SqlConnection Sconn;
        public ApplicantEvaluation()
        {
            InitializeComponent();
        }

        private void recordListToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}
