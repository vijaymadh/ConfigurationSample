using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ConfigurationValidation.akvHelper;
using ConfigurationValidation.Common;

namespace ConfigurationValidation.Adobe
{
    public partial class TestAKV : Form
    {
        public TestAKV()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            var testValue = "Adding my Test Value";
            //var accessApi = "https://api.na2.echosign.com";
            try
            {
                AzureKeyVaultHelper.ClientId = txtClientId.Text;
                AzureKeyVaultHelper.ClientSecret = txtSecret.Text;
                AzureKeyVaultHelper.VaultName = txtKeyVaultAddress.Text;
                AzureKeyVaultHelper.VaultAddress = txtKeyVaultAddress.Text;

                testValue = AzureKeyVaultHelper.CreateSecret("testValue1", testValue);
                var testKeyValue = AzureKeyVaultHelper.GetSecretByName("testValue1");
                AzureKeyVaultHelper.DeleteSecret("testValue1");
                lblResult.Text = "Success!";
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message + "\n" + ex.InnerException?.Message;
            }
        }

        private void TestAKV_Load(object sender, EventArgs e)
        {
            txtClientId.Text = Configuration.AkvClientId;
            txtSecret.Text = Configuration.AkvClientSecret;
            txtKeyVaultAddress.Text = Configuration.AkvClientKeyVaultUri;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AzureKeyVaultHelper.ClientId = txtClientId.Text;
            AzureKeyVaultHelper.ClientSecret = txtSecret.Text;
            AzureKeyVaultHelper.VaultName = txtKeyVaultAddress.Text;
            AzureKeyVaultHelper.VaultAddress = txtKeyVaultAddress.Text;


            var testVCode = AzureKeyVaultHelper.GetSecretByName("OauthRefreshCodeEchoSign");

            lblResult.Text = testVCode;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AzureKeyVaultHelper.ClientId = txtClientId.Text;
            AzureKeyVaultHelper.ClientSecret = txtSecret.Text;
            AzureKeyVaultHelper.VaultName = txtKeyVaultAddress.Text;
            AzureKeyVaultHelper.VaultAddress = txtKeyVaultAddress.Text;

            var testRefreshCode = AzureKeyVaultHelper.CreateSecret("OauthRefreshCode", txtRefreshCode.Text);
            var testAccessApiKeyName = AzureKeyVaultHelper.CreateSecret("AccessApiKeyName", txtAccessAPI.Text);

            var testVCode = AzureKeyVaultHelper.GetSecretByName("OauthRefreshCode");
            lblResult.Text = testVCode;
        }

        private void AKVList_Click(object sender, EventArgs e)
        {
            AzureKeyVaultHelper.ClientId = txtClientId.Text;
            AzureKeyVaultHelper.ClientSecret = txtSecret.Text;

            AzureKeyVaultHelper.VaultName = txtKeyVaultAddress.Text;
            AzureKeyVaultHelper.VaultAddress = txtKeyVaultAddress.Text;


            var secrets = AzureKeyVaultHelper.GetSecrets();
            dgSecrets.AutoGenerateColumns = false;
            dgSecrets.AutoSize = true;
           

            dgSecrets.Columns[0].Name = "Name";
            dgSecrets.Columns[0].HeaderText = "Secret Name";
            dgSecrets.Columns[0].DataPropertyName = "KeyName";

            dgSecrets.Columns[1].Name = "Value";
            dgSecrets.Columns[1].HeaderText = "Secret Value";
            dgSecrets.Columns[1].DataPropertyName = "KeyValue";

            var dt = new DataTable();

            dt.Columns.Add("KeyName");
            dt.Columns.Add("KeyValue");
            //var dataSource = from row in secrets select new { Name = row.Key, Value = row.Value };
            //foreach (var secret in dataSource)
            //{
            //    DataRow dataRow = dt.NewRow();
            //    dataRow["sName"] = secret.Name;
            //    dataRow["sValue"] = secret.Value;
            //    dt.Rows.Add(dataRow);
            //}

            dgSecrets.DataSource = secrets;
            MessageBox.Show("Loading data is done");
        }
    }
}
