using Aspose.Pdf;
using Aspose.Pdf.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace ConfigurationValidation.AsposePDF
{
    public partial class TextReplacement : Form
    {
        public TextReplacement()
        {
            this.InitializeComponent();
        }



        private void btnSource_Click(object sender, EventArgs e)
        {
            this.txtSource.Text = "";
            var dialogresult = this.Source.ShowDialog();
            if (dialogresult == DialogResult.Cancel)
            {
                return;
            }

            this.txtSource.Text = this.Source.FileName;
        }

        private void btnTarget_Click(object sender, EventArgs e)
        {
            this.txtTarget.Text = "";
            var dialogresult = this.target.ShowDialog();
            if (dialogresult == DialogResult.Cancel)
            {
                return;
            }

            this.txtTarget.Text = this.target.FileName;
        }

        private void TextReplacement_Load(object sender, EventArgs e)
        {
            this.txtSource.Text = @"C:\TestDevelopment\DevUtility\AsposeFiles\Source.pdf";
            this.txtTarget.Text = @"C:\TestDevelopment\DevUtility\AsposeFiles\Target.pdf";
            SetLicenses(@"C:\Development\C7Main\Common\License\aspose\Aspose.Total.lic");
        }

        public static void SetLicenses(string fileName)
        {
            var asposeLicenseFile = System.IO.File.ReadAllBytes(fileName);
            var pdfLicense = new Aspose.Pdf.License();


            using (var resourceStream = new MemoryStream(asposeLicenseFile))
            {
                pdfLicense.SetLicense(resourceStream);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public void ReplaceTextPDF()
        {
            var fileName = this.txtSource.Text;
            Aspose.Pdf.Document pdfDocument = null;
            var options = new PdfSaveOptions();
            //if (Path.GetExtension(fileName).ToUpperInvariant() != "PDF")
            //{
            //    var payload=File.ReadAllBytes(fileName);
            //    fileName = fileName.Replace(Path.GetExtension(fileName).ToUpperInvariant(), "pdf");

            //    using (var stream = new MemoryStream(payload))
            //    {
            //       var document = new Document(stream);                    
            //        document.Save(fileName, SaveFormat.Pdf);
            //    }                    
            //}

            if (Path.GetExtension(fileName).ToUpperInvariant() != ".PDF")
            {
                var payload = File.ReadAllBytes(fileName);
                fileName = fileName.Replace(Path.GetExtension(fileName), ".pdf");
                File.WriteAllBytes(fileName, payload);
            }


            pdfDocument = new Document(fileName);

            var TypeList = new List<string> {
                "Int","Ext"
            };
            
            foreach(var type in TypeList) { 
            TextFragmentCollection textFragmentCollection = this.GetTextFragments(pdfDocument, type);
            //loop through the fragments

            var TotalTextFragments = 0;

            foreach (TextFragment textFragment in textFragmentCollection.OfType<TextFragment>())
            {
                try
                {
                    TotalTextFragments++;

                    textFragment.Text = "CHANGED";

                    textFragment.TextState.FontSize = 22;

                    textFragment.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Blue);

                    textFragment.TextState.BackgroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Green);
                    //ChangeText(textFragment);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            }
            pdfDocument.Save(this.txtTarget.Text);
            MessageBox.Show("Done");
        }


        private void ChangeText(TextFragment textFragment)
        {
            var isfirst = true;
            foreach (TextSegment segment in textFragment.Segments)
            {
                if (isfirst)
                {
                    segment.Text = "CHANGED";

                    segment.TextState.FontSize = 22;

                    segment.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Blue);

                    segment.TextState.BackgroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Green);
                }
                else
                {
                    segment.Text = "";
                }
                isfirst = false;
            }
        }

        /// <summary>
        /// Get Text Fragments
        /// </summary>
        /// <param name="document">PDF Document</param>
        /// <param name="regex">Regex used to identify tag</param>
        /// <returns>Text Fragment Collection</returns>
        private TextFragmentCollection GetTextFragments(Document document, string type)
        {

            //// var textTagPattern = @"\d{1,5}(\|.*?\|[a-zA-Z0-9_-]+\|[01]{1}\|[01]{1}\|[01]{1}((\|[01]{1})?(\|[Int|Ext]\d{1,5}[Text|Checkbox])?(\|.*?\|){1}(#%#\|){1})?)?";

            ////var regex = @"Int\d{1,2}Text" + textTagPattern;

            //var regex = @"((?:(?![\n\r])\s)*)(Int|Ext)\d{1,2}Text" + textTagPattern + "(\\s*)";

            //var regex = @"(\s)*" + type + @"\d{1,2}Text\d{1,9}\|(.*?)\|(.*?)(\|(.*?[0|1])){1,9}[ ]";
            //var regex = @"(\s)*" + type + @"\d{1,2}Text\d{1,9}\|(.*?)\|(.*?)(\|(.*?[0|1])){1,9}[  ]";
            var regex = @"(\s)*" + type + @"\d{1,2}Text\d{1,9}\|(.*?)\|(.*?)(\|(.*?[0|1])){1,9}(\s)+";

            


            ////var regex = @"(\s*)(Int|Ext)\d{1,2}Text\d{1,9}\|(.*?)\|(.*?)(\|(.*?[0|1])){1,9}(\s*)";


            Aspose.Pdf.Text.TextSearchOptions textSearchOptions = new Aspose.Pdf.Text.TextSearchOptions(true);

            Aspose.Pdf.Text.TextFragmentAbsorber textFragmentAbsorber = new Aspose.Pdf.Text.TextFragmentAbsorber(regex, textSearchOptions);

            ////textFragmentAbsorber.TextSearchOptions = textSearchOptions;

            //document.Pages.Accept(textFragmentAbsorber);
            document.Pages.Accept(textFragmentAbsorber);
            //((Page)document.Pages[1]).Accept(textFragmentAbsorber);



            return textFragmentAbsorber.TextFragments;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ReplaceTextPDF();
        }
    }
}
