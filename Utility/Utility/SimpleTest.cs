using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility.ArrayManipulation;

namespace Utility
{
    public partial class SimpleTest : Form
    {
        public SimpleTest()
        {
            InitializeComponent();
        }

        private void ABCCounter_Click(object sender, EventArgs e)
        {
            ABCString abcs = new ABCString();
            string str = "xxzzyyxz";
            var retVlue = string.Empty;
            var value=abcs.GetABCCount(str, out retVlue);
            lblData.Text = retVlue;
            MessageBox.Show($"Count for {str} is {value}");
        }
    }
}
