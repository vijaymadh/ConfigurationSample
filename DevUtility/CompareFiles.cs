using System;
using System.Windows.Forms;

namespace ConfigurationValidation
{
    public partial class CompareFiles : Form
    {
        public CompareFiles()
        {
            InitializeComponent();
        }

        private void btnFile1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            lblFile1.Text = ofd.FileName;
        }

        private void btnFile2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd=new OpenFileDialog();
            ofd.ShowDialog();
            lblFile2.Text = ofd.FileName;
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            var file1 = System.IO.File.ReadAllBytes(lblFile1.Text);
            var file2 = System.IO.File.ReadAllBytes(lblFile2.Text);

            lblResult.Text = $"File 1 length {file1.Length}\n File 2 Length {file2.Length}";
        }
    }
}
