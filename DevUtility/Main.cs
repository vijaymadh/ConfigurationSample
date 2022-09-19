using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using ConfigurationValidation.Adobe;
using ConfigurationValidation.Adobe.CSV;
using ConfigurationValidation.AsposePDF;
using ConfigurationValidation.Interview;
using ConfigurationValidation.Other;
using ConfigurationValidation.ReadXmlDocumenation;
using ConfigurationValidation.TenantConfig;

namespace ConfigurationValidation
{
    public partial class Main : Form
    {
        public Main()
        {
            this.InitializeComponent();
        }

        private void tenantJSONReadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var readTenantConfig = new ReadTenantConfig();
            readTenantConfig.MdiParent = this;
            readTenantConfig.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tenantJSONCompareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CompareTenantConfig();
            form.MdiParent = this;
            form.Show();
        }

        private void adobeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new EchoSignOauthGenerator();
            form.MdiParent = this;
            form.Show();
        }

        private void aKVTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sendEchoSignDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        private void xMLDocumenReaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ReadXmlDocument();
            form.MdiParent = this;
            form.Show();
        }

        private void compareFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CompareFiles();
            form.MdiParent = this;
            form.Show();
        }

        private void checkEnvelopeStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CheckEsignEnvelope();
            form.MdiParent = this;
            form.Show();
        }

        private void aKVTestToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var form = new TestAKV();
            form.MdiParent = this;
            form.Show();
        }

        private void sendEchoSignDocumentToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var form = new SendEsignDocument();
            form.MdiParent = this;
            form.Show();
        }

        private void textRepalcementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new TextReplacement();
            form.MdiParent = this;
            form.Show();
        }

        //private void createClauseToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    new AddClauses().Createclause();
        //}

        private void convertToPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new WordToPDF();
            form.MdiParent = this;
            form.Show();
        }

        private void directCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Aspose.Pdf.License().SetLicense(@"C:\Development\C7Main\Common\License\aspose\Aspose.Total.lic");
            new Aspose.Words.License().SetLicense(@"C:\Development\C7Main\Common\License\aspose\Aspose.Total.lic");

            DirectoryInfo di = new DirectoryInfo(@"C:\TemplateFiles");
            StringBuilder sb = new StringBuilder();
            foreach (var file in di.GetFiles("*.docx", SearchOption.TopDirectoryOnly))
            {
                try
                {
                    MemoryStream outStream = new MemoryStream();
                    var docx = new Aspose.Words.Document(file.FullName);
                    // Save the document to stream.
                    docx.Save(outStream, Aspose.Words.SaveFormat.Pdf);

                    // Convert the document to byte form.
                    byte[] docBytes = outStream.ToArray();

                    // The bytes are now ready to be stored/transmitted.
                    // Now reverse the steps to load the bytes back into a document object.
                    var pdfStream = new MemoryStream(docBytes);
                    var doc = new Document(pdfStream);

                    var regEx = @"(Ext|Int)\d{1,4}Text\d{1,9}((.*?)\|\d{1}\|\d{1}\|\d{1})?";
                    TextFragmentAbsorber textFragmentAbsorber = new TextFragmentAbsorber(regEx);
                    TextSearchOptions textSearchOptions = new TextSearchOptions(true);
                    textFragmentAbsorber.TextSearchOptions = textSearchOptions;

                    doc.Pages.Accept(textFragmentAbsorber);

                    TextFragmentCollection textFragmentCollection = textFragmentAbsorber.TextFragments;

                    sb.AppendLine("file name: " + file.Name);
                    if (textFragmentCollection.Count > 0)
                    {
                        sb.AppendLine("____________________________________________________________________________");
                        foreach (TextFragment fragment in textFragmentCollection)
                        {
                            var value = fragment.Text;
                            sb.AppendLine(value);
                        }
                        sb.AppendLine("____________________________________________________________________________");                    }

                }
                catch (Exception)
                {

                }
            }

            System.IO.File.AppendAllText(@"C:\temp\AllTags.txt", sb.ToString());
        }

        private void generateOauthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new EchoSignOauthGenerator();
            form.MdiParent = this;
            form.Show();
        }

        private void interviewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void retryTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new RetryTest();
            form.MdiParent = this;
            form.Show();

        }

        private void checkMultipleEnvelopeStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CheckEsignEnvelopeMultiple();
            form.MdiParent = this;
            form.Show();
        }

        private void cancelEnvelopeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CancelEnvelope();
            form.MdiParent = this;
            form.Show();
        }

        private void checkMultipleEnvelopeStatusCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CheckEsignEnvelopeMultipleCSV();
            form.MdiParent = this;
            form.Show();
        }

        private void copyDataOnceFromDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new GetAllAgreementInfo();
            form.MdiParent = this;
            form.Show();
        }

        private void searchQuestionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FindQuestion();
            form.MdiParent = this;
            form.Show();
        }

        private void searchQuestionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new FindQuestion();
            form.MdiParent = this;
            form.Show();
        }

        private void takeInterviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new QuestionPoper();
            form.MdiParent = this;
            form.Show();
        }
    }
}
