using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personal
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void emailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new SendMail();
            frm.Show();
        }
    }
}
