namespace ConfigurationValidation.Adobe.CSV
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    using ConfigurationValidation.Common;
    using EchosignRESTClient.Helper;

    public partial class CheckEsignEnvelopeMultipleCSV : Form
    {
        public CheckEsignEnvelopeMultipleCSV()
        {
            this.InitializeComponent();
        }

        string LoadEnveloeInfo(TempCSV row)
        {
            var oauthRefreshCode = EsignCommon.GetOauthRefreshCode(this.txtAKVClientID.Text, this.txtAKVClientSecret.Text, this.txtAKVVaultUri.Text);
            var AccessApi = EsignCommon.GetAccessAPI(this.txtAKVClientID.Text, this.txtAKVClientSecret.Text, this.txtAKVVaultUri.Text);

            var echoSignRestHelper = new EchoSignRestHelper(AccessApi, this.txtEchoSignClientId.Text, this.txtEchoSignClientSecret.Text, oauthRefreshCode);
            var newEnvelopeInfo = echoSignRestHelper.GetAgreement(row.NewEnvID).Result;
            var oldEnvelopeInfo = echoSignRestHelper.GetAgreement(row.OldEnvID).Result;

            if(newEnvelopeInfo==null && oldEnvelopeInfo==null)
            {
                return "ICMAgreementCode,OldEnvID,OldEnvAdobeStatus,OldEnvLastSignedByAndDate,NewEnvID,NewEnvCreatedDate, NewEnvCancelDate,NewEnvCancelReason";
            }

            var rowData = new StringBuilder();

            var ICMAgreementCode = row.ICMAgreementCode;
            var OldEnvID = row.OldEnvID;
            var OldEnvAdobeStatus = row.OldEnvAdobeStatus;
            var OldEnvLastSignedByAndDate = string.Empty;

            var signedEvents = oldEnvelopeInfo?.events?.FindAll(x => x.type == "ESIGNED");

            foreach(var signedEvent in signedEvents)
            {
                OldEnvLastSignedByAndDate += $"[SignedBy: {signedEvent.actingUserEmail} Signed On: {signedEvent.date}]";
            }
            
            var NewEnvID = row.NewEnvID;

            var createdEvent = newEnvelopeInfo?.events?.Find(x => x.type == "CREATED");
            var NewEnvCreatedDate = createdEvent?.date;

            var cancledEvent = newEnvelopeInfo?.events?.Find(x => x.type.Contains("CANCELLED"));
            var NewEnvCancelDate = cancledEvent?.date;
            var NewEnvCancelReason = $"{cancledEvent?.type}-{cancledEvent?.description}";

            return $"{ICMAgreementCode},{OldEnvID},{OldEnvAdobeStatus},{OldEnvLastSignedByAndDate},{NewEnvID},{NewEnvCreatedDate}, {NewEnvCancelDate},{NewEnvCancelReason}";
            
        }

        void CheckEsignEnvelope_Load(object sender, EventArgs e)
        {
            this.txtAKVClientID.Text = Configuration.AkvClientId;
            this.txtAKVClientSecret.Text = Configuration.AkvClientSecret;
            this.txtAKVVaultUri.Text = Configuration.AkvClientKeyVaultUri;
            this.txtEchoSignClientId.Text = Configuration.EchoSignClientId;
            this.txtEchoSignClientSecret.Text = Configuration.EchoSignClientSecret;
        }

        string LoadDocumentStatus(List<TempCSV> data)
        {
            var csvBulder = new StringBuilder();
            var counter = 0;
            foreach (var row in data)
            {
                counter++;

                if (counter != 5)
                {
                    continue;
                }

                counter = 0;
                try
                {
                    csvBulder.AppendLine(this.LoadEnveloeInfo(row));
                }
                catch
                {
                    csvBulder.AppendLine("envelopeid");
                }
            }

            return csvBulder.ToString();
        }


        void btnLoad_Click(object sender, EventArgs e)
        {
            using (var reader = new StreamReader(@"C:\Work\Production Support\Daimler Issue\DataFromAmol_CSV.csv"))
            {
                var data = new List<TempCSV>();            
                while (!reader.EndOfStream)
                {
                    
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    data.Add(new TempCSV
                    {
                        ICMAgreementCode = values[0],
                        OldEnvID = values[1].ToString(),
                        OldEnvAdobeStatus = values[2].ToString(),
                        NewEnvID = values[3].ToString()
                    });
                }

                var result = this.LoadDocumentStatus(data);
                File.WriteAllText(@"C:\Work\Production Support\Daimler Issue\DataFromAmol_CSV_Result.csv", result);

                MessageBox.Show("Data processed successfully");
            }

        }
    }
}
