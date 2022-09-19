using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utility.BaseDerived
{
    public partial class TestBaseDerived : Form
    {
        public TestBaseDerived()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var obj = GetDObjectAsBase();
            label1.Text = $"Name:{((DClass)obj).Name} Age:{((DClass)obj).Age}";
        }

        private BClass GetDObjectAsBase()
        {
            return new DClass
            {
                Name = "Vijay Soni",
                Age = "Not Known"
            };
        }
    }
}
