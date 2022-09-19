using System;
using System.Text;
using System.Windows.Forms;
using ConfigurationValidation.Common;
using EchosignRESTClient.Helper;

namespace ConfigurationValidation.Adobe
{
    public partial class CheckEsignEnvelope : Form
    {
        public CheckEsignEnvelope()
        {
            this.InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var oauthRefreshCode = EsignCommon.GetOauthRefreshCode(txtAKVClientID.Text,txtAKVClientSecret.Text, txtAKVVaultUri.Text);
            var AccessApi = EsignCommon.GetAccessAPI(txtAKVClientID.Text, txtAKVClientSecret.Text, txtAKVVaultUri.Text);

            var echoSignRestHelper = new EchoSignRestHelper(AccessApi, txtEchoSignClientId.Text, txtEchoSignClientSecret.Text, oauthRefreshCode);
            var agreementInfo = echoSignRestHelper.GetAgreement(txtEnvelopeId.Text).Result;
            
            var result =new StringBuilder( $"\nEnvelopeStatus:{agreementInfo.status}\n");
            result.AppendLine($"Events:");
            var count = 0;
            foreach(var eve in agreementInfo.events)
            {
                count++;
                result.AppendLine($"    Event{count}");
                result.AppendLine($"            date:{eve.date}");
                result.AppendLine($"            description:{eve.description}");
                result.AppendLine($"            versionId:{eve.versionId}");
                result.AppendLine($"            actingUserEmail:{eve.actingUserEmail}");
                result.AppendLine($"            actingUserIpAddress:{eve.actingUserIpAddress}");
                result.AppendLine($"            participantEmail:{eve.participantEmail}");
                result.AppendLine($"            type:{eve.type}");
            }
            result.AppendLine($"=============== Participients -------------");
            foreach (var ps in agreementInfo.participantSetInfos)
            {
                result.AppendLine($"    Email ID: {ps.participantSetMemberInfos[0]?.email}");
                result.AppendLine($"    Name: {ps.participantSetMemberInfos[0]?.name}");
                result.AppendLine($"    Adobe ID: {ps.participantSetMemberInfos[0]?.participantId}");
                result.AppendLine($"    Status: {ps.status}");
                result.AppendLine($"------------------------------------------------");
            }

            txtResult.Text = result.ToString();
            //var pendingParticipents = agreementInfo.nextParticipantSetInfos != null ? agreementInfo.nextParticipantSetInfos.Count.ToString() : "0";
                        
            ///EnvelopeInfo = agreementInfo == null? "Envelope Not Found":$"Agreemen ID: {agreementInfo.agreementId}\r\n Pending Participents:{pendingParticipents}\r\n Status:{agreementInfo.status}\r\nEntity Name:{agreementInfo.message}";
            ///txtResult.Text = EnvelopeInfo;
                
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
