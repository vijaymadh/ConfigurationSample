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
    public partial class TestCode : Form
    {
        public TestCode()
        {
            InitializeComponent();

            var c=new CClass();
            c.name = "Vijay";
            MessageBox.Show(c.name);
            ((BClass) c).name = "Vijay 2";
            MessageBox.Show(c.name);
            MessageBox.Show(((BClass)c).name);



        }
    }

    public class BClass
    {
        public string name { get; set; }
    }
    public class CClass:BClass
    {
        public string name { get; set; }
    }

}
