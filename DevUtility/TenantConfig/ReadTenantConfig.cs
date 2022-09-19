using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ConfigurationValidation.TenantConfig.Models;
using Newtonsoft.Json;

namespace ConfigurationValidation.TenantConfig
{
    public partial class ReadTenantConfig : Form
    {
        public ReadTenantConfig()
        {
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            var dialogresult = TenantJsonfileDialogue.ShowDialog();
            string inputJson = "";
            if (dialogresult == DialogResult.Cancel)
            {
                return;
            }

            var myStream = TenantJsonfileDialogue.OpenFile();
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

            ConfigModel obj = JsonConvert.DeserializeObject<ConfigModel>(inputJson);

            dgvConfig.Columns.Add( "PropertyName", "Property Name");
            dgvConfig.Columns.Add("PropertyValue", "Property Value");

            dgvConfig.Columns[0].Width = 500;
            dgvConfig.Columns[1].Width = 900;

            var lstAllConfig = new List<Config>();

            foreach (var propertyGroup in obj.data[0].Tenants[0].tenantPropertyGroups)
            {
                foreach (var property in propertyGroup.properties)
                {
                    lstAllConfig.Add(property);
                }
            }

            foreach (var property in lstAllConfig.OrderBy(x=>x.Name))
            {
                var row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell { Value = property.Name });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = property.Value });
                dgvConfig.Rows.Add(row);
            }
        }
    }
}
