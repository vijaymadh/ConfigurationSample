using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utility
{
    public partial class JSSanitize : Form
    {
        public JSSanitize()
        {
            InitializeComponent();
        }

        public static string CleanHTMLFromScript(string str)
        {
            //Regex re = new Regex("<script[^>]*>", RegexOptions.IgnoreCase);
            //str = re.Replace(str, "");
            //re = new Regex("<[a-z][^>]*on[a-z]+=\"?[^\"]*\"?[^>]*>", RegexOptions.IgnoreCase);
            //str = re.Replace(str, "");
            //re = new Regex("<a\\s+href\\s*=\\s*\"?\\s*javascript:[^\"]*\"[^>]*>", RegexOptions.IgnoreCase);
            //str = re.Replace(str, "");
            //return (str);



            Regex re = new Regex("?<=<\\w+)((?:\\s+)((?:on\\w+=((\"[^\"]*\")|('[^']*')|(.*?)))| (?< a > (? !on)\\w += ((\"[^\"]*\")|('[^']*')|(.*?)))))*(?=/?>", RegexOptions.IgnoreCase);
            str = re.Replace(str, "");
             
            return str;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(CleanHTMLFromScript(textBox1.Text));
        }
    }
}
