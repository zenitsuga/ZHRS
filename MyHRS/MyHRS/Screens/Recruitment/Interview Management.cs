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
    public partial class Interview_Management : Form
    {
        public Interview_Management()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListModule lm = new ListModule();
            lm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListModule lm = new ListModule();
            lm.ShowDialog();
        }
    }
}
