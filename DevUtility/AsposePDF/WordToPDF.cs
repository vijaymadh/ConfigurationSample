using Aspose.Words;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfigurationValidation.AsposePDF
{
    public partial class WordToPDF : Form
    {
        public WordToPDF()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var payload = File.ReadAllBytes(@"C:\Work\Bug\468396\Tags Corrected.docx");
            GeneratePDF(payload, 0);
        }

        public void GeneratePDF(
        byte[] documentBytes,
        int pages = 0)
        {
            ////License license = new Aspose.Words.License();
            ////if (this.licenseObject != null)
            ////{
            ////    using (var resourceStream = new MemoryStream(this.licenseObject))
            ////    {
            ////        license.SetLicense(new MemoryStream(this.licenseObject));
            ////    }
            ////}

            // Override load options to skip default loading of external resources
            Aspose.Words.LoadOptions loadOptions = new Aspose.Words.LoadOptions();
            loadOptions.PreserveIncludePictureField = true;
            //loadOptions.ResourceLoadingCallback = new BanNetworkAccessHandler();

            Document target;
            using (MemoryStream docxStream = new MemoryStream(documentBytes))
            {
                target = new Aspose.Words.Document(docxStream, loadOptions);
            }

            MemoryStream pdfStream = new MemoryStream();

            //// Get the first shape from the every header and if its image, wrap it using type Square to avoid getting it truncated #
            Aspose.Words.HeaderFooterType[] headers = new Aspose.Words.HeaderFooterType[] { Aspose.Words.HeaderFooterType.HeaderEven, Aspose.Words.HeaderFooterType.HeaderFirst, Aspose.Words.HeaderFooterType.HeaderPrimary };
            foreach (var header in headers)
            {
                var shape = (Aspose.Words.Drawing.Shape)target.FirstSection?.HeadersFooters[header]?.GetChild(NodeType.Shape, 0, true);
                if (shape != null && shape.ShapeType == Aspose.Words.Drawing.ShapeType.Image && shape.GetAncestor(NodeType.StructuredDocumentTag) == null)
                {
                    shape.WrapType = Aspose.Words.Drawing.WrapType.Square;
                }
            }

            

            //SetDocumentPropertiesPostRevisionAcception(ref target);
            target.Save(pdfStream, Aspose.Words.SaveFormat.Pdf);

            //return this.GetPDFPages(pdfStream.ToArray(), pages);
            File.WriteAllBytes(@"C:\TestDevelopment\DevUtility\AsposeFiles\converted.pdf", pdfStream.ToArray());
        }

        private void WordToPDF_Load(object sender, EventArgs e)
        {
            
            SetLicenses(@"C:\Development\C7Main\Common\License\aspose\Aspose.Total.lic");
        }

        public static void SetLicenses(string fileName)
        {
            var asposeLicenseFile = System.IO.File.ReadAllBytes(fileName);
            var pdfLicense = new Aspose.Words.License();


            using (var resourceStream = new MemoryStream(asposeLicenseFile))
            {
                pdfLicense.SetLicense(resourceStream);
            }
        }
    }
}
