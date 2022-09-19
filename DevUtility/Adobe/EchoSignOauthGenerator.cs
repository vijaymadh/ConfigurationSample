using System;
using System.Net;
using System.Windows.Forms;
using ConfigurationValidation.Common;
using EchosignRESTClient;

namespace ConfigurationValidation.Adobe
{
    public partial class EchoSignOauthGenerator : Form
    {
        public EchoSignOauthGenerator()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            EchosignREST rest = new EchosignREST(txtAccessUrl.Text, txtClientID.Text, txtSecret.Text);
            rest.GetRefreshToken(txtOAuthCode.Text, txtCallBackUrl.Text).Wait();
            txtRefreshToken.Text = rest.RefreshToken;
            txtRefreshToken.SelectAll();
        }

        private void EchoSignOauthGenerator_Load(object sender, EventArgs e)
        {

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            txtCallBackUrl.Text = Configuration.EsignCallBackUrl+ "/ESignCallBack/EchoSignAuthorizationCallBack";
            ////txtCallBackUrl.Text = "https://622e7b6b.ngrok.io";
          
            txtClientID.Text = Configuration.EchoSignClientId;
            txtSecret.Text = Configuration.EchoSignClientSecret;
            txtAccessUrl.Text = Configuration.accessapikey;
            
            ////Group Scope
            txtSampleUrl.Text =
                $"https://secure.na2.echosign.com/public/oauth?redirect_uri={txtCallBackUrl.Text}&response_type=code&client_id={txtClientID.Text}&scope=user_read:group user_write:group user_login:group agreement_read:group agreement_write:group agreement_send:group widget_read:group widget_write:group";

            ////Account Scope
            //txtSampleUrl.Text =
            //    $"https://secure.na2.echosign.com/public/oauth?redirect_uri={txtCallBackUrl.Text}&response_type=code&client_id={txtClientID.Text}&scope=user_read:account user_write:account user_login:account agreement_read:account agreement_write:account agreement_send:account widget_read:account widget_write:account";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshValues();
        }

        private void RefreshValues()
        {
            var webhookScope = " webhook_read:group webhook_write:group webhook_retention:group";
            txtSampleUrl.Text =
                $"{txtAccountUrl.Text}/public/oauth/v2?redirect_uri={txtCallBackUrl.Text}&response_type=code&client_id={txtClientID.Text}&scope=user_read:group user_write:group user_login:group agreement_read:group agreement_write:group agreement_send:group";

            txtSampleUrl.Text += (chkWebHook.Checked) ? webhookScope : string.Empty; 
        }

        private void cboVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshValues();
        }

        private void txtAPIUrl_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
