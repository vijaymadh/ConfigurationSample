// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EchoSignDocumentHelper.cs" company="Icertis Inc.">
//   Copyright (c) 2014 Icertis Inc. All Rights Reserved.
// </copyright>
// <summary>
//   Summary of the class goes here
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Icertis.CLM.ESignAdapter.ESignHelper
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using ACF.EntityService.Data;
    using Aspose.Pdf;
    using Aspose.Pdf.Text;
    using ESignUtil;
    using Utilities;

    /// <summary>
    /// Document Helper Class
    /// </summary>
    public static class EchoSignDocumentHelper
    {
        /// <summary>
        /// The tag patterns
        /// </summary>
        private const string tagPatterns = @"\d{1,5}(\|.*?\|ICM[a-zA-Z0-9_-]+\|[01]{1}\|[01]{1}\|[01]{1})?";

        /// <summary>
        /// The text tag pattern
        /// </summary>
        private const string textTagPattern = @"\d{1,5}(\|.*?\|[a-zA-Z0-9_-]+\|[01]{1}\|[01]{1}\|[01]{1}((\|[01]{1})?(\|[Int|Ext]\d{1,5}[Text|Checkbox])?(\|.*?\|){1}(#%#\|){1})?)?";

        /// <summary>
        /// The check box tag pattern
        /// </summary>
        private const string checkBoxTagPattern = @"\d{1,5}}(\|.*?\|([01]{1})?(\|[Int|Ext]\d{1,5}[Text|Checkbox])?(\|.*?\|){1}(#%#\|){1})?";

        /// <summary>
        /// This method updates the signature blocks in the document and returns the updated document
        /// </summary>
        /// <param name="payLoad">source payload</param>
        /// <param name="signatureRegex">signature regular expression</param>
        /// <param name="signatoryInformation">Signatory Information</param>
        /// <param name="eSignAttributeMappings">The e sign attribute mappings.</param>
        /// <param name="agreementInstance">The agreement instance.</param>
        /// <returns>updated document</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Aspose.Pdf.Text.TextFragment.set_Text(System.String)", Justification = "This is echo sign implementation for the signature tags. The string can be a passed as a literal.")]
        public static byte[] UpdateSignature(byte[] payLoad)
        {
            byte[] final = null;
            SetLicense();
            int maxSignOrder = 0;
            int maxSignOrderForCustomization = 0;

            bool internalSignatureFirst = false;
            int externalSignatories = 0;
            int internalSignatories = 0;

            

                using (MemoryStream output = new MemoryStream())
                {
                    document.Save(output);
                    final = output.ToArray();
                }
            }


            // Pulling All the fragments for checkbox / textbox string to use it later in the application 
            Aspose.Pdf.Text.TextFragmentAbsorber findAllCheckboxString = new Aspose.Pdf.Text.TextFragmentAbsorber(@"[Int|Ext]{3}\d{1,10}Checkbox" + checkBoxTagPattern);
            Aspose.Pdf.Text.TextFragmentAbsorber findAllTextboxString = new Aspose.Pdf.Text.TextFragmentAbsorber(@"[Int|Ext]{3}\d{1,10}Text" + textTagPattern);
            using (MemoryStream stream = new MemoryStream(payLoad))
            {
                Document document = new Document(stream);
                findAllCheckboxString.TextSearchOptions = new Aspose.Pdf.Text.TextSearchOptions(true);
                document.Pages.Accept(findAllCheckboxString);
                document.Pages.Accept(findAllTextboxString);
            }

            var allTextFragments = findAllCheckboxString.TextFragments.Cast<Aspose.Pdf.Text.TextFragment>();
            allTextFragments = allTextFragments.Concat(findAllTextboxString.TextFragments.Cast<Aspose.Pdf.Text.TextFragment>());


            byte[] finalDocument = null;
            var intSigners = signatoryInformation.Where(x => x.SignatoryRole == SignatoryRole.InternalSignatory).ToList();
            var extSigners = signatoryInformation.Where(x => x.SignatoryRole == SignatoryRole.ExternalSignatory).ToList();


            maxSignOrder = 0;

            if (!internalSignatureFirst)
            {
                //// Aspose is unable to replace the text for multiple text fragments. Hence, final document is passed.

                finalDocument = ReplaceExternalDates(final, externalSignatories, ref maxSignOrder);
                maxSignOrder = 0;
                finalDocument = ReplaceExternalTextBoxes(finalDocument, ref maxSignOrder, extSigners, ref eSignAttributeMappings, agreementInstance, allTextFragments);
                maxSignOrder = 0;
                finalDocument = ReplaceExternalCheckBoxes(finalDocument, ref maxSignOrder, extSigners, ref eSignAttributeMappings, agreementInstance, allTextFragments);

                int maxSignOrderOriginal = maxSignOrderForCustomization = Math.Max(maxSignOrder, externalSignatories);

                finalDocument = ReplaceInternalDates(finalDocument, internalSignatories, ref maxSignOrder);
                maxSignOrder = maxSignOrderOriginal;
                finalDocument = ReplaceInternalTextBoxes(finalDocument, ref maxSignOrder, intSigners, ref eSignAttributeMappings, agreementInstance, allTextFragments);
                maxSignOrder = maxSignOrderOriginal;
                finalDocument = ReplaceInternalCheckBoxes(finalDocument, ref maxSignOrder, intSigners, ref eSignAttributeMappings, agreementInstance, allTextFragments);
            }
            else
            {
                //// Aspose is unable to replace the text for multiple text fragments. Hence, final document is passed.

                finalDocument = ReplaceInternalDates(final, internalSignatories, ref maxSignOrder);
                maxSignOrder = 0;
                finalDocument = ReplaceInternalTextBoxes(finalDocument, ref maxSignOrder, intSigners, ref eSignAttributeMappings, agreementInstance, allTextFragments);
                maxSignOrder = 0;
                finalDocument = ReplaceInternalCheckBoxes(finalDocument, ref maxSignOrder, intSigners, ref eSignAttributeMappings, agreementInstance, allTextFragments);

                int maxSignOrderOriginal = maxSignOrderForCustomization = Math.Max(maxSignOrder, internalSignatories);
                finalDocument = ReplaceExternalDates(finalDocument, externalSignatories, ref maxSignOrder);
                maxSignOrder = maxSignOrderOriginal;
                finalDocument = ReplaceExternalTextBoxes(finalDocument, ref maxSignOrder, extSigners, ref eSignAttributeMappings, agreementInstance, allTextFragments);
                maxSignOrder = maxSignOrderOriginal;
                finalDocument = ReplaceExternalCheckBoxes(finalDocument, ref maxSignOrder, extSigners, ref eSignAttributeMappings, agreementInstance, allTextFragments);
            }

            //// Hook for Replacing the Client Specific Custom Tags with Supported EchoSign Tags
            var finalDocumentAfterCustomTagsReplaced = CustomizationHelper.ProcessCustomEchoSignPlaceholdersEventHook(finalDocument, signatoryInformation.Cast<object>().ToArray(), internalSignatureFirst, maxSignOrderForCustomization, agreementInstance);
            if (finalDocumentAfterCustomTagsReplaced != null && finalDocumentAfterCustomTagsReplaced is byte[])
            {
                finalDocument = (byte[])finalDocumentAfterCustomTagsReplaced;
            }

            return finalDocument;
        }

        /// <summary>
        /// Tag signature sequence for External signatories in the document.
        /// </summary>
        /// <param name="maxSignOrder"> Max External Sign Order</param>
        /// <param name="externalSignatories">List of External Signatories</param>
        /// <param name="textFragmentCollection">Text Fragment Collection</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Aspose.Pdf.Text.TextFragment.set_Text(System.String)", Justification = "ToDo")]
        private static void TagExternalSignatoriesInDocument(ref int maxSignOrder, int externalSignatories, Aspose.Pdf.Text.TextFragmentCollection textFragmentCollection)
        {
            int i = 1;

            foreach (Aspose.Pdf.Text.TextFragment item in textFragmentCollection)
            {
                if (item.Text.Contains("Ext"))
                {
                    if (i > externalSignatories)
                    {
                        break;
                    }

                    int signOrder = Convert.ToInt32(item.Text.Split(':')[1], CultureInfo.InvariantCulture);
                    int newOrder = maxSignOrder + signOrder;
                    string signatureText = "signer" + newOrder;
                    string text = "{{_es_:" + signatureText + ":signature}}";
                    item.Text = text;
                    i++;
                }
            }

            maxSignOrder = maxSignOrder + (i - 1);
        }

        /// <summary>
        /// Tag signature sequence for internal signatories in the document.
        /// </summary>
        /// <param name="maxSignOrder">Maximum External Sign. Order</param>
        /// <param name="internalSignatories">List of External Signatories</param>
        /// <param name="textFragmentCollection">Text Fragment Collection</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Aspose.Pdf.Text.TextFragment.set_Text(System.String)", Justification = "ToDo")]
        private static void TagInternalSignatoriesInDocument(ref int maxSignOrder, int internalSignatories, Aspose.Pdf.Text.TextFragmentCollection textFragmentCollection)
        {
            int i = 1;
            foreach (Aspose.Pdf.Text.TextFragment item in textFragmentCollection)
            {
                if (item.Text.Contains("Int"))
                {
                    if (i > internalSignatories)
                    {
                        break;
                    }

                    int signOrder = Convert.ToInt32(item.Text.Split(':')[1], CultureInfo.InvariantCulture);
                    int newOrder = maxSignOrder + signOrder;
                    string signatureText = "signer" + newOrder;
                    string text = "{{_es_:" + signatureText + ":signature}}";
                    item.Text = text;
                    i++;
                }
            }

            maxSignOrder = maxSignOrder + (i - 1);
        }

        /// <summary>
        /// Replaces external date tags
        /// </summary>
        /// <param name="payLoad">input document</param>
        /// <param name="externalSignatories">external Signatories</param>
        ///  <param name="maxSignOrder">maximumn Sign Order</param>
        /// <returns>output document</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Aspose.Pdf.Text.TextFragment.set_Text(System.String)", Justification = "This is echo sign implementation for the signature tags. The string can be a passed as a literal.")]
        private static byte[] ReplaceExternalDates(byte[] payLoad, int externalSignatories, ref int maxSignOrder)
        {
            byte[] final = null;

            using (MemoryStream stream = new MemoryStream(payLoad))
            {
                Document document = new Document(stream);
                Aspose.Pdf.Text.TextSearchOptions textSearchOptions = new Aspose.Pdf.Text.TextSearchOptions(true);

                Aspose.Pdf.Text.TextFragmentAbsorber dateFragmentAbsorber = new Aspose.Pdf.Text.TextFragmentAbsorber(@"ExtDate\d{1,2}");
                dateFragmentAbsorber.TextSearchOptions = textSearchOptions;
                document.Pages.Accept(dateFragmentAbsorber);
                Aspose.Pdf.Text.TextFragmentCollection dateFragmentCollection = dateFragmentAbsorber.TextFragments;
                int i = 1;

                if (externalSignatories > 0)
                {
                    foreach (Aspose.Pdf.Text.TextFragment item in dateFragmentCollection)
                    {
                        if (item.Text.Contains("ExtDate"))
                        {
                            if (i > externalSignatories)
                            {
                                break;
                            }

                            var signatoryNumber = Regex.Match(item.Text, @"\d+").Value;

                            int signOrder = 0;
                            int.TryParse(signatoryNumber, out signOrder);

                            int newOrder = maxSignOrder + signOrder;
                            string signatureText = "signer" + newOrder;
                            string text = "{{Dte_es_:" + signatureText + ":date}}";
                            item.Text = text;
                            i++;
                        }
                    }
                }

                using (MemoryStream output = new MemoryStream())
                {
                    document.Save(output);
                    final = output.ToArray();
                }

                maxSignOrder = maxSignOrder + i - 1;

                return final;
            }
        }

        /// <summary>
        /// Replaces the external text boxes.
        /// </summary>
        /// <param name="payLoad">The pay load.</param>
        /// <param name="maxSignOrder">Max Sign order.</param>
        /// <param name="signers">The signers.</param>
        /// <param name="eSignAttributeMappings">The e sign attribute mappings.</param>
        /// <param name="agreementInstance">The agreement instance.</param>
        /// <param name="allTextFragments">All text fragments.</param>
        /// <returns>output document</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Aspose.Pdf.Text.TextFragment.set_Text(System.String)", Justification = "This is echo sign implementation for the signature tags. The string can be a passed as a literal.")]
        private static byte[] ReplaceExternalTextBoxes(byte[] payLoad, ref int maxSignOrder, List<ESignSignatoryInformation> signers, ref IList<ESignAttributeAdapter> eSignAttributeMappings, EntityBase agreementInstance, IEnumerable<TextFragment> allTextFragments)
        {
            byte[] final = null;
            var i = 1;
            using (MemoryStream stream = new MemoryStream(payLoad))
            {
                Document document = new Document(stream);
                var textFragmentCollection = GetTextFragments(document, @"Ext\d{1,2}Text" + textTagPattern);
                if (signers.Any())
                {
                    foreach (Aspose.Pdf.Text.TextFragment item in textFragmentCollection)
                    {
                        var signerEmail = string.Empty;
                        if (item.Text.Contains("Ext"))
                        {
                            int signerSignOrder = -1;
                            if (i > signers.Count)
                            {
                                break;
                            }

                            ESignAttributeAdapter attributeMapping = CreateAttributeMapping(signers, ref eSignAttributeMappings, agreementInstance, item, ref signerEmail, ref signerSignOrder, @"^Ext(\d{1,2})", allTextFragments);
                            string tag = GetTextBoxString(@"Ext\d{1,2}", item.Text, maxSignOrder, attributeMapping);

                            ////Add refrence tag to the last page of the document stream
                            item.Text = CreateReferenceTag(tag, ref document); ////- commented CreateReferenceTag call because tis is 

                            if (item.TextState != null && item.TextState.FontSize < 12)
                            {
                                item.TextState.FontSize = 12;
                            }

                            i++;
                        }
                    }
                }

                using (MemoryStream output = new MemoryStream())
                {
                    document.Save(output);
                    final = output.ToArray();
                }
            }
            maxSignOrder = maxSignOrder + (i - 1);
            return final;
        }

        /// <summary>
        /// Creates the reference tag.
        /// </summary>
        /// <param name="itemTagText">The item tag text.</param>
        /// <param name="attributeMapping">The attribute mapping.</param>
        /// <param name="document">The document.</param>
        private static string CreateReferenceTag(string itemTagText, ref Document document)
        {
            var originalText = itemTagText;
            var randomNumber = RandomSequenceGenerator.Next(1000, 9999);
            var itemText = string.Format(null, "{0}{0}$CustomeText{2}{1}{1}", "{", "}", randomNumber);
            itemText = originalText.Replace("{{", string.Format(null, "{0}{0}#CustomeText{1}=", "{", randomNumber)); ;

            var page = document.Pages.Add();
            TextBuilder txtbuilder = new TextBuilder(page);
            TextFragment wideFragment = new TextFragment(originalText + Environment.NewLine + "{{#REMOVE_PAGE_FROM_OUTPUT}}");
            txtbuilder.AppendText(wideFragment);

            return itemText;
        }

        /// <summary>
        /// Get Text Fragments
        /// </summary>
        /// <param name="document">PDF Document</param>
        /// <param name="regex">Regex used to identify tag</param>
        /// <returns>Text Fragment Collection</returns>
        private static TextFragmentCollection GetTextFragments(Document document, string regex)
        {
            Aspose.Pdf.Text.TextSearchOptions textSearchOptions = new Aspose.Pdf.Text.TextSearchOptions(true);

            Aspose.Pdf.Text.TextFragmentAbsorber textFragmentAbsorber = new Aspose.Pdf.Text.TextFragmentAbsorber(regex);
            textFragmentAbsorber.TextSearchOptions = textSearchOptions;
            document.Pages.Accept(textFragmentAbsorber);
            return textFragmentAbsorber.TextFragments;
        }

        /// <summary>
        /// Creates the attribute mapping.
        /// </summary>
        /// <param name="signers">The signers.</param>
        /// <param name="eSignAttributeMappings">The e sign attribute mappings.</param>
        /// <param name="agreementInstance">The agreement instance.</param>
        /// <param name="item">The item.</param>
        /// <param name="signerEmail">The signer email.</param>
        /// <param name="signerSignOrder">The signer sign order.</param>
        /// <returns>ESignatory attribute adapter field</returns>
        private static ESignAttributeAdapter CreateAttributeMapping(List<ESignSignatoryInformation> signers, ref IList<ESignAttributeAdapter> eSignAttributeMappings, EntityBase agreementInstance, TextFragment item, ref string signerEmail, ref int signerSignOrder, string extSignOrderPatternString, IEnumerable<TextFragment> allTextFragments)
        {
            var extSignOrderPattern = new Regex(extSignOrderPatternString);
            var matches = extSignOrderPattern.Match(item.Text);

            if (matches.Success && matches.Groups.Count > 1)
            {
                var extSignOrder = matches.Groups[1].Value;
                var currentSigner = signers.FirstOrDefault(x => x.SignOrder == Convert.ToInt64(extSignOrder));
                if (currentSigner != null)
                {
                    signerEmail = currentSigner.EmailId;
                    signerSignOrder = currentSigner.SignOrder;
                }
            }

            eSignAttributeMappings = ESignUtility.AddESignAttributeMapping(eSignAttributeMappings, item.Text, signerEmail, signerSignOrder, allTextFragments);
            var attributeMapping = eSignAttributeMappings.FirstOrDefault(x => x.ESignTagText == item.Text);
            if (attributeMapping != null && agreementInstance.PropertyExists(attributeMapping.AttributeName))
            {
                attributeMapping.AttributeValue = Convert.ToString(agreementInstance.Get(attributeMapping.AttributeName), null);
            }

            return attributeMapping;
        }

        /// <summary>
        ///  Replace External CheckBoxes
        /// </summary>
        /// <param name="payLoad">input document payload</param>
        /// <param name="maxSignOrder">maximum Signature order</param>
        /// <param name="signers">List of all Signers</param>
        /// <param name="eSignAttributeMappings">The e sign attribute mappings</param>
        /// <param name="agreementInstance">Agreement</param>
        /// <param name="allTextFragments">All text fragments.</param>
        /// <returns>Modified document</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Aspose.Pdf.Text.TextFragment.set_Text(System.String)", Justification = "This is echo sign implementation for the signature tags. The string can be a passed as a literal.")]
        private static byte[] ReplaceExternalCheckBoxes(byte[] payLoad, ref int maxSignOrder, List<ESignSignatoryInformation> signers, ref IList<ESignAttributeAdapter> eSignAttributeMappings, EntityBase agreementInstance, IEnumerable<TextFragment> allTextFragments)
        {
            byte[] final = null;
            int i = 1;
            using (MemoryStream stream = new MemoryStream(payLoad))
            {
                Document document = new Document(stream);
                var checkBoxFragmentCollection = GetTextFragments(document, @"Ext\d{1,2}Checkbox" + checkBoxTagPattern);
                if (signers.Any())
                {

                    foreach (Aspose.Pdf.Text.TextFragment item in checkBoxFragmentCollection)
                    {
                        var signerEmail = string.Empty;
                        int signerSignOrder = -1;
                        if (item.Text.Contains("Ext"))
                        {
                            if (i > signers.Count)
                            {
                                break;
                            }

                            ESignAttributeAdapter attributeMapping = CreateAttributeMapping(signers, ref eSignAttributeMappings, agreementInstance, item, ref signerEmail, ref signerSignOrder, @"^Ext(\d{1,2})", allTextFragments);
                            string tag = GetCheckBoxString(@"Ext\d{1,2}", item.Text, maxSignOrder, attributeMapping);
                            item.Text = tag;
                            i++;
                        }
                    }
                }

                using (MemoryStream output = new MemoryStream())
                {
                    document.Save(output);
                    final = output.ToArray();
                }
            }
            maxSignOrder = maxSignOrder + (i - 1);
            return final;
        }

        /// <summary>
        /// Replace Internal Signatures
        /// </summary>
        /// <param name="payLoad">input document</param>
        /// <param name="maxSignOrder">max external signatures</param>
        /// <param name="internalSignatories">internal Signatories</param>
        /// <returns>output document</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Aspose.Pdf.Text.TextFragment.set_Text(System.String)", Justification = "This is echo sign implementation for the signature tags. The string can be a passed as a literal.")]
        private static byte[] ReplaceInternalDates(byte[] payLoad, int internalSignatories, ref int maxSignOrder)
        {
            byte[] final = null;

            using (MemoryStream stream = new MemoryStream(payLoad))
            {
                Document document = new Document(stream);
                Aspose.Pdf.Text.TextSearchOptions textSearchOptions = new Aspose.Pdf.Text.TextSearchOptions(true);
                Aspose.Pdf.Text.TextFragmentAbsorber dateIntFragmentAbsorber = new Aspose.Pdf.Text.TextFragmentAbsorber(@"IntDate\d{1,2}");
                dateIntFragmentAbsorber.TextSearchOptions = textSearchOptions;
                document.Pages.Accept(dateIntFragmentAbsorber);
                Aspose.Pdf.Text.TextFragmentCollection dateIntFragmentCollection = dateIntFragmentAbsorber.TextFragments;
                int i = 1;

                foreach (Aspose.Pdf.Text.TextFragment item in dateIntFragmentCollection)
                {
                    if (item.Text.Contains("IntDate"))
                    {
                        if (i > internalSignatories)
                        {
                            break;
                        }

                        var signatoryNumber = Regex.Match(item.Text, @"\d+").Value;

                        int signOrder = 0;
                        int.TryParse(signatoryNumber, out signOrder);

                        int newOrder = maxSignOrder + signOrder;
                        string signatureText = "signer" + newOrder;
                        string text = "{{Dte_es_:" + signatureText + ":date}}";
                        item.Text = text;
                        i++;
                    }
                }

                using (MemoryStream output = new MemoryStream())
                {
                    document.Save(output);
                    final = output.ToArray();
                }

                maxSignOrder = maxSignOrder + i - 1;

                return final;
            }
        }

        /// <summary>
        /// Replace Internal Signatures Text Boxes
        /// </summary>
        /// <param name="payLoad">input document</param>
        /// <param name="maxSignOrder">max Sign Order</param>
        /// <param name="signers">List of all Signers</param>
        /// <param name="eSignAttributeMappings">The e sign attribute mappings</param>
        /// <param name="agreementInstance">Agreement</param>
        /// <returns>output document</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Aspose.Pdf.Text.TextFragment.set_Text(System.String)", Justification = "This is echo sign implementation for the signature tags. The string can be a passed as a literal.")]
        private static byte[] ReplaceInternalTextBoxes(byte[] payLoad, ref int maxSignOrder, List<ESignSignatoryInformation> signers, ref IList<ESignAttributeAdapter> eSignAttributeMappings, EntityBase agreementInstance, IEnumerable<TextFragment> allTextFragments)
        {
            byte[] final = null;
            var i = 1;
            using (MemoryStream stream = new MemoryStream(payLoad))
            {
                Document document = new Document(stream);
                var textFragmentCollection = GetTextFragments(document, @"Int\d{1,2}Text" + textTagPattern);

                foreach (TextFragment item in textFragmentCollection)
                {
                    var signerEmail = string.Empty;

                    if (item.Text.Contains("Int"))
                    {
                        int signerSignOrder = -1;
                        if (i > signers.Count)
                        {
                            break;
                        }

                        ESignAttributeAdapter attributeMapping = CreateAttributeMapping(signers, ref eSignAttributeMappings, agreementInstance, item, ref signerEmail, ref signerSignOrder, @"^Int(\d{1,2})", allTextFragments);
                        string tag = GetTextBoxString(@"Int\d{1,2}", item.Text, maxSignOrder, attributeMapping);

                        ////Add refrence tag to the last page of the document stream
                        item.Text = CreateReferenceTag(tag, ref document);

                        if (item.TextState != null && item.TextState.FontSize < 12)
                        {
                            item.TextState.FontSize = 12;
                        }

                        i++;
                    }
                }

                using (MemoryStream output = new MemoryStream())
                {
                    document.Save(output);
                    final = output.ToArray();
                }
                maxSignOrder = maxSignOrder + (i - 1);
                return final;
            }
        }

        /// <summary>
        /// Replace Internal Signatures Check boxes
        /// </summary>
        /// <param name="payLoad">input document</param>
        /// <param name="maxSignOrder">max external signatures</param>
        /// <param name="signers">internal Signatories</param>
        /// <returns>output document</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Aspose.Pdf.Text.TextFragment.set_Text(System.String)", Justification = "This is echo sign implementation for the signature tags. The string can be a passed as a literal.")]
        private static byte[] ReplaceInternalCheckBoxes(byte[] payLoad, ref int maxSignOrder, List<ESignSignatoryInformation> signers, ref IList<ESignAttributeAdapter> eSignAttributeMappings, EntityBase agreementInstance, IEnumerable<TextFragment> allTextFragments)
        {
            byte[] final = null;
            int i = 1;
            using (MemoryStream stream = new MemoryStream(payLoad))
            {
                Document document = new Document(stream);
                var checkBoxFragmentCollection = GetTextFragments(document, @"Int\d{1,2}Checkbox" + checkBoxTagPattern);

                foreach (Aspose.Pdf.Text.TextFragment item in checkBoxFragmentCollection)
                {
                    var signerEmail = string.Empty;
                    if (item.Text.Contains("Int"))
                    {
                        int signerSignOrder = -1;
                        if (i > signers.Count)
                        {
                            break;
                        }

                        ESignAttributeAdapter attributeMapping = CreateAttributeMapping(signers, ref eSignAttributeMappings, agreementInstance, item, ref signerEmail, ref signerSignOrder, @"^Int(\d{1,2})", allTextFragments);
                        string tag = GetCheckBoxString(@"Int\d{1,2}", item.Text, maxSignOrder, attributeMapping);
                        item.Text = tag;
                        i++;
                    }
                }

                using (MemoryStream output = new MemoryStream())
                {
                    document.Save(output);
                    final = output.ToArray();
                }
                maxSignOrder = maxSignOrder + (i - 1);
                return final;
            }
        }

        /// <summary>
        /// Set ASPOSE license
        /// </summary>
        private static void SetLicense()
        {
            var pdfLicense = new Aspose.Pdf.License();

            using (var resourceStream = new MemoryStream(Icertis.CLM.Utilities.License.GetAsposeTotalLicense))
            {
                pdfLicense.SetLicense(resourceStream);
            }
        }

        /// <summary>
        /// Get Text Box String
        /// </summary>
        /// <param name="regex">Regex used to identify tag</param>
        /// <param name="tagText">Tagged text in template</param>
        /// <param name="externalSignatoryOrder">number of external signatories</param>
        /// <returns>final ECHOSIGN compatible tag</returns>
        private static string GetTextBoxString(string regex, string tagText, int maxSignOrder, ESignAttributeAdapter attributeMapping)
        {
            var externalSignatoryTag = Regex.Match(tagText, regex).Value;
            var signatoryNumber = Regex.Match(externalSignatoryTag, @"\d+").Value;

            int signOrder = 0;
            int.TryParse(signatoryNumber, out signOrder);
            int newOrder = maxSignOrder + signOrder;
            string signatureText = "signer" + newOrder;
            string label = tagText;
            string text = "{{" + label + "_es_:textfield:" + signatureText;

            if (attributeMapping != null)
            {
                if (attributeMapping.IsMandatory)
                {
                    text = text + ":required";
                }

                if (attributeMapping.IsReadOnly)
                {
                    text = text + ":locked";
                }

                if (!string.IsNullOrWhiteSpace(attributeMapping.TagLabel))
                {
                    text = text + ":tooltip(" + attributeMapping.TagLabel + ")";
                }

                if (!string.IsNullOrWhiteSpace(attributeMapping.AttributeValue))
                {
                    text = text + ":default(" + attributeMapping.AttributeValue + ")";
                }
            }

            text = text + "}}";
            return text;
        }

        /// <summary>
        /// Get Check Box String
        /// </summary>
        /// <param name="regex">Regex used to identify tag</param>
        /// <param name="tagText">Tagged text in template</param>        
        /// <param name="maxSignOrder">number of external signatories</param>
        /// <returns>final ECHOSIGN compatible tag</returns>
        private static string GetCheckBoxString(string regex, string tagText, int maxSignOrder, ESignAttributeAdapter attributeMapping)
        {
            var externalSignatoryTag = Regex.Match(tagText, regex).Value;
            var signatoryNumber = Regex.Match(externalSignatoryTag, @"\d+").Value;

            int signOrder = 0;
            int.TryParse(signatoryNumber, out signOrder);
            int newOrder = maxSignOrder + signOrder;
            string signatureText = "signer" + newOrder;
            string label = tagText;
            string text = "{{" + label + "_es_:checkbox:" + signatureText;

            if (attributeMapping != null)
            {
                if (attributeMapping.IsMandatory)
                {
                    text = text + ":required";
                }

                if (attributeMapping.IsReadOnly)
                {
                    text = text + ":locked";
                }

                if (!string.IsNullOrWhiteSpace(attributeMapping.TagLabel))
                {
                    text = text + ":tooltip(" + attributeMapping.TagLabel + ")";
                }

                if (!string.IsNullOrWhiteSpace(attributeMapping.AttributeValue))
                {
                    text = text + ":default(" + attributeMapping.AttributeValue + ")";
                }
            }

            text = text + "}}";

            return text;
        }
    }
}
