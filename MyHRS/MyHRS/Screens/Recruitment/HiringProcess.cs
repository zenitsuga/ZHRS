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
    public partial class HiringProcess : Form
    {
        public HiringProcess()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((panelPersonalInfo.Height - 7) != btnPersonalInfo.Height)
            {
                panelPersonalInfo.Height = btnPersonalInfo.Height + 7;
            }
            else
            {
                panelPersonalInfo.Height = (panel1.Height - panelStatus.Height);
            }
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            if ((panelStatus.Height - 7) != btnStatus.Height)
            {
                panelStatus.Height = btnStatus.Height + 7;
            }
            else
            {
                panelStatus.Height = (panel1.Height - panelPersonalInfo.Height);
            }
        }
    }
}
