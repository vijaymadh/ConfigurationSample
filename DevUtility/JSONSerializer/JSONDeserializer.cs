using System;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ConfigurationValidation.JSONSerializer
{
    public partial class JSONDeserializer : Form
    {
        public JSONDeserializer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string json = "{\"name\":\"mmmm\",\"male\":\"true\",\"age\":\"100\"}";
            Cat cat = JsonConvert.DeserializeObject<Cat>(json);

            lblResult.Text = $"Name: {cat.Name}\n Age: {cat.Age} \nIs Male: {cat.Male}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string json = "{\"name\":\"mmmm\",\"someprop\":\"true\"}";
            string json = "{\"name\":\"mmmm\"}";
            Cat cat = JsonConvert.DeserializeObject<Cat>(json);

            lblResult.Text = $"Name: {cat.Name}\n Age: {cat.Age} \nIs Male: {cat.Male}";
        }
    }
}
