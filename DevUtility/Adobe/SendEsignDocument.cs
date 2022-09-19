using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ConfigurationValidation.Common;
using EchosignRESTClient.Helper;
using EchosignRESTClient.Models;
using EchosignRESTClient.Models.AgreementInfo;
using EchosignRESTClient.Models.AgreementView;
using EchosignRESTClient.Models.WebHook;

namespace ConfigurationValidation.Adobe
{
    public partial class SendEsignDocument : Form
    {
        public SendEsignDocument()
        {
            this.InitializeComponent();
        }

        private void btnSendDocument_Click(object sender, EventArgs e)
        {
            this.txtevelope.Text = "";
            var dialogresult = this.Document.ShowDialog();
            if (dialogresult == DialogResult.Cancel)
            {
                return;
            }

            var rest = this.EchoSignRestHelperObject;
            var payload = System.IO.File.ReadAllBytes(this.Document.FileName);

            var transientDocument = rest.UploadTransientDocument("Template", payload, "application/pdf").Result;

            #region This is as per 6.0
            var agreementInfo = new AgreementInfo
            {

                //options = new InteractiveOptions() { autoLoginUser = true },
                /////, locale = "fr_FR" },////, authoringRequested = UploadOnly }, ////This will be added once we provide preview and send
                ////local = "fr_FR",
                //daysUntilSigningDeadline = 4,
                fileInfos = new List<EchosignRESTClient.Models.FileInfo>() { new EchosignRESTClient.Models.FileInfo { transientDocumentId = transientDocument.transientDocumentId } },
                //// Document Message can be customized, for core message = Name. check GetDocusignDocument function of EchoSignDocument class for more info.
                message = "Sent for Test signature from utility",
                participantSetInfos = GetRecipientInfo(new List<string> { "vijay.soni@icertis.com", "vijaymadh@gmail.com" }),
                name = "Test Document from utility",
                ccs = new List<CcInfo>(),
                signatureType = "ESIGN",
                state = "IN_PROCESS"


                //state = "IN_PROCESS","AUTHORING"
                //,locale = "fr_FR"

            };
            #endregion

            #region This is as per 5.0
            //        var agreementMinmalRequest = new AgreementMinimalRequest
            //        {
            //            Options = new InteractiveOptions()
            //            {
            //                AutoLoginUser = true,
            //                AuthoringRequested = UploadOnly,
            //                NoChrome = true/*While sending agreement for signature if NoChrome is set to true then Account settings of logged in user will not be editable in preview and send popup*/
            //            },
            //            DocumentCreationInfo = new DocumentCreationInfo
            //            {
            //                 Removed DaysUntilSigningDeadline which was set to 3.
            //                 There are 2 ways to set DaysUntilSigningDeadline,
            //                 1. Set it in the API call like here (which is commented now)
            //                 2. Set it at AdobeSign account level
            //                 If we do not pass through API it set expiration date as per AdobeSign account settings
            //                 We can add config key keep it configurable, however for time being it is commented.
            //                 configure to use
            //                FileInfos = additionalDocumentsUpdated.Select(x => new FileInfo { TransientDocumentId = x.TransientDocumentId }).ToList(),
            //                // Document Message can be customized, for core message = Name. check GetDocusignDocument function of AdobeSignDocument class for more info.
            //                Message = documentInformation.Message,
            //                RecipientSetInfos = GetRecipientInfo(signatoryInformation, enablePhoneAuthentication),
            //                Name = documentInformation.Subject,
            //                Ccs = documentInformation.CCList,
            //                SignatureType = mandateWetSignaturesinAdobeSign ? SignatureType.WRITTEN.ToString() : SignatureType.ESIGN.ToString(),
            //                CallbackInfo = callbackInfo
            //            }
            //};
            #endregion

            var response = rest.CreateAgreement(agreementInfo).Result;
            if (response == null)
            {
                MessageBox.Show("Something is wrong");
            }

            this.txtevelope.Text = response.id;
            this.CreateWebHook(rest, response.id);
            this.ViewAgreement(rest, response.id);
            MessageBox.Show("Uploaded Successfully");
        }

        private void ViewAgreement(IEchoSignRestHelper rest, string agreementId)
        {
            var agreementViewInfo = new AgreementViewInfo {
                name= "AUTHORING",
                commonViewConfiguration =new CommonViewConfiguration
                {
                    autoLoginUser=true,                    
                    noChrome=true
                }
            };

            var response = rest.ViewAgreement(agreementId,agreementViewInfo).Result;
            
            var url = response.agreementViewList[0].url;            

            this.txtPSUrl.Text = url;
        }

        private void CreateWebHook(IEchoSignRestHelper rest, string agreementId)
        {
            var webHookInfo = new WebhookInfo()
            {
                name = $"WebHook-{Configuration.accessapikey}",
                scope = "RESOURCE",
                state = "ACTIVE",
                webhookSubscriptionEvents = new List<string>() { "AGREEMENT_REJECTED", "AGREEMENT_ACTION_COMPLETED", "AGREEMENT_WORKFLOW_COMPLETED", "AGREEMENT_ACTION_DELEGATED", "AGREEMENT_ACTION_REQUESTED" },
                webhookUrlInfo = new WebhookUrlInfo()
                {
                    url = $"{Configuration.EsignCallBackUrl}/serviceapi/ESignCallBack/EchoSignCallBack"
                },
                applicationDisplayName = "Vijay Test Application",
                resourceId = agreementId,
                resourceType = "AGREEMENT"
            };

            var response = rest.CreateWebHook(webHookInfo).Result;
            if (response == null)
            {
                MessageBox.Show("Something is wrong");
                return;
            }

            this.txtWebHookId.Text = response.id;
        }

        /// <summary>
        /// EchoSign Authentication Information
        /// </summary>
        private IEchoSignRestHelper echoSignRestHelperObject;

        /// <summary>
        /// 
        /// </summary>
        public IEchoSignRestHelper EchoSignRestHelperObject
        {
            get
            {
                if (this.echoSignRestHelperObject == null)
                {

                    var oauthRefreshCode = EsignCommon.GetOauthRefreshCode();
                    var AccessApi = EsignCommon.GetAccessAPI();
                    this.echoSignRestHelperObject = new EchoSignRestHelper(AccessApi, Configuration.EchoSignClientId, Configuration.EchoSignClientSecret, oauthRefreshCode);
                }
                return this.echoSignRestHelperObject;
            }
            set => this.echoSignRestHelperObject = value;
        }

        private static List<ParticipantSetInfo> GetRecipientInfo(List<string> recipients)
        {
            var order = 0;

            var participantList = new List<ParticipantSetInfo>();
            foreach (var signatory in recipients)
            {
                order++;

                var participantSetMemberInfos = new List<ParticipantInfo>()
                    {
                       new ParticipantInfo()

                        {
                            email = signatory,
                            securityOption = new ParticipantSecurityOption()
                            {
                                authenticationMethod = "NONE"
                            }
                        }
                    };

                var participant = new ParticipantSetInfo()
                {
                    signingOrder = order,
                    name = "Vijay" + "Soni" + order.ToString(),
                    participantSetMemberInfos = participantSetMemberInfos

                };

                participant.roles=new List<string>{"SIGNER" };


                participantList.Add(participant);
            }

            return participantList;
        }

        /// <summary>
        /// Set ASPOSE license
        /// </summary>
        private static void SetLicense()
        {
            var pdfLicense = new Aspose.Pdf.License();

            using (var resourceStream = new MemoryStream(File.ReadAllBytes("Aspose.Total.lic")))
            {
                pdfLicense.SetLicense(resourceStream);
            }
        }
    }
}
