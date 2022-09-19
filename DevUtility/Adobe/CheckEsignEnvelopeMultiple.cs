using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ConfigurationValidation.Common;
using EchosignRESTClient.Helper;

namespace ConfigurationValidation.Adobe
{
    public partial class CheckEsignEnvelopeMultiple : Form
    {
        public CheckEsignEnvelopeMultiple()
        {
            this.InitializeComponent();
        }

        private string LoadEnveloeInfo(string envelopeId, List<string> requirements)
        {
            var oauthRefreshCode = EsignCommon.GetOauthRefreshCode(txtAKVClientID.Text, txtAKVClientSecret.Text, txtAKVVaultUri.Text);
            var AccessApi = EsignCommon.GetAccessAPI(txtAKVClientID.Text, txtAKVClientSecret.Text, txtAKVVaultUri.Text);

            var echoSignRestHelper = new EchoSignRestHelper(AccessApi, txtEchoSignClientId.Text, txtEchoSignClientSecret.Text, oauthRefreshCode);
            var agreementInfo = echoSignRestHelper.GetAgreement(envelopeId).Result;

            var data = new StringBuilder();

            data.Append($"{envelopeId}");

            foreach (var req in requirements)
            {
                switch (req)
                {
                    case "EnvelopeStatus":
                        data.Append($",{agreementInfo.status}");
                        break;
                    case "CreatedDate":
                        var createdEvent = agreementInfo?.events?.Find(x => x.type == "CREATED");
                        var createdDate =  $"{createdEvent.date}";
                        data.Append($",{createdDate}");
                        break;
                    case "CanceledDate":
                        var cancledEvent = agreementInfo?.events?.Find(x => x.type.Contains("CANCELLED"));
                        var cancledDate = cancledEvent == null ? "" : $"{cancledEvent.date}";
                        data.Append($",{cancledDate}");
                        data.Append($",{cancledEvent?.type}-{cancledEvent?.description}");
                        break;
                    case "DocumentStatus":
                        var deletedEvent = agreementInfo?.events?.Find(x => x.type == "DOCUMENTS_DELETED");
                        var docStatus = deletedEvent == null ? "Documents Not Deleted - " : $"{deletedEvent?.description}";
                        data.Append($",{docStatus}"); 
                        break;
                }

            }
           
            
            return data.ToString();
        }

        private void CheckEsignEnvelope_Load(object sender, EventArgs e)
        {
            this.txtAKVClientID.Text = Configuration.AkvClientId;
            this.txtAKVClientSecret.Text = Configuration.AkvClientSecret;
            this.txtAKVVaultUri.Text = Configuration.AkvClientKeyVaultUri;
            this.txtEchoSignClientId.Text = Configuration.EchoSignClientId;
            this.txtEchoSignClientSecret.Text = Configuration.EchoSignClientSecret;
        }


        //private string LoadDocumentStatus(string[] envelopeids, List<string> requirements)
        //{
        //    var csvBulder = new StringBuilder();
        //    csvBulder.AppendLine("EnvelopeId,EnvelopeStatus,DocumentStatus");
        //    foreach (var envelopeid in envelopeids)
        //    {
        //        csvBulder.AppendLine(LoadEnveloeInfo(envelopeid, requirements));
        //    }

        //    return csvBulder.ToString();
        //}

        private string LoadDocumentStatus(string[] envelopeids, List<string> requirements)
        {
            var csvBulder = new StringBuilder();
            var header = "EnvelopeId";
            foreach (var requiment in requirements)
            {
                header += "," + requiment;
            }

            csvBulder.AppendLine(header);
            foreach (var envelopeid in envelopeids)
            {
                try
                {
                    csvBulder.AppendLine(LoadEnveloeInfo(envelopeid, requirements));
                }
                catch (Exception ex)
                {
                    csvBulder.AppendLine("envelopeid");
                }               
            }

            return csvBulder.ToString();
        }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            var requirements = new List<string> { "EnvelopeStatus", "CreatedDate", "CancleComments", "CanceledDate" ,};
            var envelopeids = txtEnvelopeIds.Text.Split('|');
            
            txtResult.Text = LoadDocumentStatus(envelopeids, requirements);
        }
    }
}
