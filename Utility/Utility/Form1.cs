using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utility
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            StringBuilder sbGuids = new StringBuilder();
            for(int count=1;count<=Convert.ToInt32( txtCount.Text) ; count++)
            {
                sbGuids.AppendLine(Guid.NewGuid().ToString());
            }
            txtResult.Text = sbGuids.ToString();
        }
    }
}
