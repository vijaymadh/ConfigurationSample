using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ConfigurationValidation.TenantConfig.Models;
using Newtonsoft.Json;

namespace ConfigurationValidation.TenantConfig
{
    public partial class CompareTenantConfig : Form
    {
        public CompareTenantConfig()
        {
            InitializeComponent();
        }

        private string file1Json = string.Empty;
        private string file2Json = string.Empty;
        private void btnCompare_Click(object sender, EventArgs e)
        {
            using (StreamReader reader = new StreamReader(lblFile1.Text))
            {
                file1Json = reader.ReadToEnd();
            }

            using (StreamReader reader = new StreamReader(lblFile2.Text))
            {
                file2Json = reader.ReadToEnd();
            }

            var tenant1List = GetList(file1Json);
            var tenant2List = GetList(file2Json);

            if (tenant1List == null || !tenant1List.Any() || tenant2List == null || !tenant2List.Any())
            {
                MessageBox.Show("Please upload valid JSON");
            }


            dgvConfig.Rows.Clear();
            dgvConfig.Columns.Clear();

            dgvConfig.Columns.Add("PropertyName", "Property Name");
            dgvConfig.Columns.Add("PropertyValueTenant1", "Property Value Tenant1");
            dgvConfig.Columns.Add("PropertyValueTenant2", "Property Value Tenant2");
            dgvConfig.Columns.Add("MatchingStatus", "Matching Status");

            dgvConfig.Columns[0].Width = 300;
            dgvConfig.Columns[1].Width = 400;
            dgvConfig.Columns[2].Width = 400;
            dgvConfig.Columns[3].Width = 200;

            foreach (var property1 in tenant1List.OrderBy(x => x.Name))
            {
                var row = new DataGridViewRow();

                //// row.DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.Green }; ;

                row.Cells.Add(new DataGridViewTextBoxCell { Value = property1.Name, ToolTipText = property1.Name });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = property1.Value, ToolTipText = property1.Value });

                var property2 = tenant2List.Where(x => x.Name == property1.Name).FirstOrDefault();
                if (property2 == null)
                {
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = "" });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = "Not Found", ToolTipText = "Not Found" });
                    row.DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.Orange };
                }
                else
                {
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = property2.Value });
                    if (property1.Value.ToLower().Equals(property2.Value.ToLower()))
                    {
                        row.Cells.Add(new DataGridViewTextBoxCell { Value = "Matched", ToolTipText = "Matched" });
                    }
                    else
                    {
                        row.Cells.Add(new DataGridViewTextBoxCell { Value = "Did Not Matched", ToolTipText = "Did Not Matched" });
                        row.DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.Orange }; ;
                    }
                }
                dgvConfig.Rows.Add(row);
            }

        }

        private List<Config> GetList(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return null;
            }

            var obj = JsonConvert.DeserializeObject<ConfigModel>(json);

            var lstTenant1Config = new List<Config>();

            foreach (var propertyGroup in obj.data[0].Tenants[0].tenantPropertyGroups)
            {
                foreach (var property in propertyGroup.properties)
                {
                    lstTenant1Config.Add(property);
                }
            }

            return lstTenant1Config.OrderBy(x => x.Name).ToList();
        }

        private void btnSelect2_Click(object sender, EventArgs e)
        {
            var dialogresult = TenantJsonfileDialogue.ShowDialog();

            if (dialogresult == DialogResult.Cancel)
            {
                return;
            }

            lblFile2.Text = TenantJsonfileDialogue.FileName;
        }

        private void btnSelectFile1_Click(object sender, EventArgs e)
        {
            var dialogresult = TenantJsonfileDialogue.ShowDialog();
            if (dialogresult == DialogResult.Cancel)
            {
                return;
            }
            lblFile1.Text = TenantJsonfileDialogue.FileName;
        }
    }
}
