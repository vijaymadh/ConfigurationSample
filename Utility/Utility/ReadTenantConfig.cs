using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.IO;

namespace Utility
{
    public partial class ReadTenantConfig : Form
    {
        public ReadTenantConfig()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dialogresult = openFileDialog1.ShowDialog();
            string inputJson = "";
            if (dialogresult == DialogResult.Cancel)
            {
                return;
            }

            var myStream = openFileDialog1.OpenFile();
            if (myStream == null)
            {
                return;
            }
            using (var reader = new StreamReader(myStream, Encoding.UTF8))
            {
                inputJson = reader.ReadToEnd();
            }

            if (string.IsNullOrWhiteSpace(inputJson))
            {
                return;
            }

            //JavaScriptSerializer js = new JavaScriptSerializer();
            //var deserializedDictionary = js.Deserialize<Dictionary<string, object>>(inputJson);

            ConfigDesig obj = JsonConvert.DeserializeObject<ConfigDesig>(inputJson);
            var csv = string.Empty;
            foreach (var propertyGroup in obj.data[0].Tenants[0].tenantPropertyGroups)
            {
                foreach (var property in propertyGroup.properties)
                {
                    csv += property.name + "=" + property.value + "\n";
                }
            }

            txtOutput.Text=csv;
        }
    }
}
