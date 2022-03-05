using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flipnic_Video_Deocde
{
    public partial class Unattend : Form
    {
        public Unattend()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                if (!Program.unattended)
                {
                    this.Close();
                }
                Program.f1.Hide();
                progressBar1.Maximum = Program.max;
                progressBar1.Value = Program.progress;
                label3.Text = string.Format("Frame: {0}/{1}", Program.progress, Program.max);
            }
        }
    }
}
