using System;
using System.Windows.Forms;
using ConfigurationValidation.RetryMechanism;

namespace ConfigurationValidation.Other
{
    public partial class RetryTest : Form
    {
        public RetryTest()
        {
            this.InitializeComponent();
        }

        string param1 = "Vijay Soni";
        int param2 = 41;        
        int retry = 1;

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = string.Empty;
            label2.Text = string.Empty;
            retry = 1;

            Func<string> someCall = delegate ()
            {
                return TestRetry(param1);                
            };            

           var result = new RetryHandler().ExecuteFunctionWithRetry<string>(someCall);

            label1.Text += result;
        }

        string TestRetry(string name)
        {
            label2.Text += $"Name:{name}-{retry}\n";
            
            retry++;
            if (retry <= 10)
            {
                throw new Exception(name);
            }
            return null;
            
        }

        string TestRetry2(string name,int age)
        {            
            label2.Text += $"Name:{name}-Age{age}-{retry}\n";
            retry++;
            if (retry <= 4)
            {
                throw new Exception(name);
            }
            return null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = string.Empty;
            label1.Text = string.Empty;
            retry = 1;

            Func<string> someCall = delegate ()
            {
                return TestRetry2(param1, param2);
            };

            var result = new RetryHandler().ExecuteFunctionWithRetry<string>(someCall);

            label1.Text += result;
        }
    }
}
