using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyHRS.Screens.Recruitment
{
    public partial class ApplicantProfile : Form
    {
        public ApplicantProfile()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnPersonalProfile_Click(object sender, EventArgs e)
        {
            if (btnPersonalProfile.Height != panel_Personal_Profile.Height)
            {
                panel_Personal_Profile.Height = btnPersonalProfile.Height;
            }else
            {
                panel_Personal_Profile.Height = 93;
            }
            
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

        
    }
}
