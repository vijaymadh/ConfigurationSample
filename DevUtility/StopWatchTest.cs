using System;
using System.Windows.Forms;

namespace ConfigurationValidation
{
    public partial class StopWatchTest : Form
    {
        public StopWatchTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sw=new System.Diagnostics.Stopwatch();
            sw.Start();
            var a = 900;
            var b = 1;
            while (b < a)
            {
                System.Threading.Thread.Sleep(5);
               
            }
            sw.Stop();
        }
    }
}
