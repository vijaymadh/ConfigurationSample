using System;
using System.Text;
using System.Windows.Forms;
using ConfigurationValidation.Common;
using EchosignRESTClient.Helper;

namespace ConfigurationValidation.Adobe
{
    public partial class CancelEnvelope : Form
    {
        public CancelEnvelope()
        {
            this.InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to cancel this envelope ??",
                                     "Confirm Cancellation!!",
                                     MessageBoxButtons.YesNo);
            if(confirmResult==DialogResult.No)
            {
                txtResult.Text = "Nothing Changed";
                return;
            }

            var oauthRefreshCode = EsignCommon.GetOauthRefreshCode(txtAKVClientID.Text,txtAKVClientSecret.Text, txtAKVVaultUri.Text);
            var AccessApi = EsignCommon.GetAccessAPI(txtAKVClientID.Text, txtAKVClientSecret.Text, txtAKVVaultUri.Text);

            var echoSignRestHelper = new EchoSignRestHelper(AccessApi, txtEchoSignClientId.Text, txtEchoSignClientSecret.Text, oauthRefreshCode);

           var result= echoSignRestHelper.CancelAgreement(txtEnvelopeId.Text, "Recalled from ICI", true).Result;
            
            txtResult.Text = (result)? $"Envelope {txtEnvelopeId.Text} has been cancled": $"Envelope {txtEnvelopeId.Text} has not been cancled";            
                
        }



        private void CheckEsignEnvelope_Load(object sender, EventArgs e)
        {
            this.txtAKVClientID.Text = Configuration.AkvClientId;
            this.txtAKVClientSecret.Text = Configuration.AkvClientSecret;
            this.txtAKVVaultUri.Text = Configuration.AkvClientKeyVaultUri;
            this.txtEchoSignClientId.Text = Configuration.EchoSignClientId;
            this.txtEchoSignClientSecret.Text = Configuration.EchoSignClientSecret;
        }
    }
}
