/* 
 * DocuSign REST API
 *
 * The DocuSign REST API provides you with a powerful, convenient, and simple Web services API for interacting with DocuSign.
 *
 * OpenAPI spec version: v2.1
 * Contact: devcenter@docusign.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = DocuSign.eSign.Client.SwaggerDateConverter;

namespace DocuSign.eSign.Model
{
    /// <summary>
    /// EnvelopePublishTransaction
    /// </summary>
    [DataContract]
    public partial class EnvelopePublishTransaction :  IEquatable<EnvelopePublishTransaction>, IValidatableObject
    {
        public EnvelopePublishTransaction()
        {
            // Empty Constructor
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnvelopePublishTransaction" /> class.
        /// </summary>
        /// <param name="ApplyConnectSettings">ApplyConnectSettings.</param>
        /// <param name="EnvelopeCount">EnvelopeCount.</param>
        /// <param name="EnvelopeLevelErrorRollups">EnvelopeLevelErrorRollups.</param>
        /// <param name="EnvelopePublishTransactionId">EnvelopePublishTransactionId.</param>
        /// <param name="ErrorCount">ErrorCount.</param>
        /// <param name="FileLevelErrors">FileLevelErrors.</param>
        /// <param name="NoActionRequiredEnvelopeCount">NoActionRequiredEnvelopeCount.</param>
        /// <param name="ProcessedEnvelopeCount">ProcessedEnvelopeCount.</param>
        /// <param name="ProcessingStatus">ProcessingStatus.</param>
        /// <param name="ResultsUri">ResultsUri.</param>
        /// <param name="SubmissionDate">SubmissionDate.</param>
        /// <param name="SubmittedByUserInfo">SubmittedByUserInfo.</param>
        /// <param name="SubmittedForPublishingEnvelopeCount">SubmittedForPublishingEnvelopeCount.</param>
        public EnvelopePublishTransaction(string ApplyConnectSettings = default(string), string EnvelopeCount = default(string), List<EnvelopePublishTransactionErrorRollup> EnvelopeLevelErrorRollups = default(List<EnvelopePublishTransactionErrorRollup>), string EnvelopePublishTransactionId = default(string), string ErrorCount = default(string), List<string> FileLevelErrors = default(List<string>), string NoActionRequiredEnvelopeCount = default(string), string ProcessedEnvelopeCount = default(string), string ProcessingStatus = default(string), string ResultsUri = default(string), string SubmissionDate = default(string), UserInfo SubmittedByUserInfo = default(UserInfo), string SubmittedForPublishingEnvelopeCount = default(string))
        {
            this.ApplyConnectSettings = ApplyConnectSettings;
            this.EnvelopeCount = EnvelopeCount;
            this.EnvelopeLevelErrorRollups = EnvelopeLevelErrorRollups;
            this.EnvelopePublishTransactionId = EnvelopePublishTransactionId;
            this.ErrorCount = ErrorCount;
            this.FileLevelErrors = FileLevelErrors;
            this.NoActionRequiredEnvelopeCount = NoActionRequiredEnvelopeCount;
            this.ProcessedEnvelopeCount = ProcessedEnvelopeCount;
            this.ProcessingStatus = ProcessingStatus;
            this.ResultsUri = ResultsUri;
            this.SubmissionDate = SubmissionDate;
            this.SubmittedByUserInfo = SubmittedByUserInfo;
            this.SubmittedForPublishingEnvelopeCount = SubmittedForPublishingEnvelopeCount;
        }
        
        /// <summary>
        /// Gets or Sets ApplyConnectSettings
        /// </summary>
        [DataMember(Name="applyConnectSettings", EmitDefaultValue=false)]
        public string ApplyConnectSettings { get; set; }
        /// <summary>
        /// Gets or Sets EnvelopeCount
        /// </summary>
        [DataMember(Name="envelopeCount", EmitDefaultValue=false)]
        public string EnvelopeCount { get; set; }
        /// <summary>
        /// Gets or Sets EnvelopeLevelErrorRollups
        /// </summary>
        [DataMember(Name="envelopeLevelErrorRollups", EmitDefaultValue=false)]
        public List<EnvelopePublishTransactionErrorRollup> EnvelopeLevelErrorRollups { get; set; }
        /// <summary>
        /// Gets or Sets EnvelopePublishTransactionId
        /// </summary>
        [DataMember(Name="envelopePublishTransactionId", EmitDefaultValue=false)]
        public string EnvelopePublishTransactionId { get; set; }
        /// <summary>
        /// Gets or Sets ErrorCount
        /// </summary>
        [DataMember(Name="errorCount", EmitDefaultValue=false)]
        public string ErrorCount { get; set; }
        /// <summary>
        /// Gets or Sets FileLevelErrors
        /// </summary>
        [DataMember(Name="fileLevelErrors", EmitDefaultValue=false)]
        public List<string> FileLevelErrors { get; set; }
        /// <summary>
        /// Gets or Sets NoActionRequiredEnvelopeCount
        /// </summary>
        [DataMember(Name="noActionRequiredEnvelopeCount", EmitDefaultValue=false)]
        public string NoActionRequiredEnvelopeCount { get; set; }
        /// <summary>
        /// Gets or Sets ProcessedEnvelopeCount
        /// </summary>
        [DataMember(Name="processedEnvelopeCount", EmitDefaultValue=false)]
        public string ProcessedEnvelopeCount { get; set; }
        /// <summary>
        /// Gets or Sets ProcessingStatus
        /// </summary>
        [DataMember(Name="processingStatus", EmitDefaultValue=false)]
        public string ProcessingStatus { get; set; }
        /// <summary>
        /// Gets or Sets ResultsUri
        /// </summary>
        [DataMember(Name="resultsUri", EmitDefaultValue=false)]
        public string ResultsUri { get; set; }
        /// <summary>
        /// Gets or Sets SubmissionDate
        /// </summary>
        [DataMember(Name="submissionDate", EmitDefaultValue=false)]
        public string SubmissionDate { get; set; }
        /// <summary>
        /// Gets or Sets SubmittedByUserInfo
        /// </summary>
        [DataMember(Name="submittedByUserInfo", EmitDefaultValue=false)]
        public UserInfo SubmittedByUserInfo { get; set; }
        /// <summary>
        /// Gets or Sets SubmittedForPublishingEnvelopeCount
        /// </summary>
        [DataMember(Name="submittedForPublishingEnvelopeCount", EmitDefaultValue=false)]
        public string SubmittedForPublishingEnvelopeCount { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EnvelopePublishTransaction {\n");
            sb.Append("  ApplyConnectSettings: ").Append(ApplyConnectSettings).Append("\n");
            sb.Append("  EnvelopeCount: ").Append(EnvelopeCount).Append("\n");
            sb.Append("  EnvelopeLevelErrorRollups: ").Append(EnvelopeLevelErrorRollups).Append("\n");
            sb.Append("  EnvelopePublishTransactionId: ").Append(EnvelopePublishTransactionId).Append("\n");
            sb.Append("  ErrorCount: ").Append(ErrorCount).Append("\n");
            sb.Append("  FileLevelErrors: ").Append(FileLevelErrors).Append("\n");
            sb.Append("  NoActionRequiredEnvelopeCount: ").Append(NoActionRequiredEnvelopeCount).Append("\n");
            sb.Append("  ProcessedEnvelopeCount: ").Append(ProcessedEnvelopeCount).Append("\n");
            sb.Append("  ProcessingStatus: ").Append(ProcessingStatus).Append("\n");
            sb.Append("  ResultsUri: ").Append(ResultsUri).Append("\n");
            sb.Append("  SubmissionDate: ").Append(SubmissionDate).Append("\n");
            sb.Append("  SubmittedByUserInfo: ").Append(SubmittedByUserInfo).Append("\n");
            sb.Append("  SubmittedForPublishingEnvelopeCount: ").Append(SubmittedForPublishingEnvelopeCount).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            return this.Equals(obj as EnvelopePublishTransaction);
        }

        /// <summary>
        /// Returns true if EnvelopePublishTransaction instances are equal
        /// </summary>
        /// <param name="other">Instance of EnvelopePublishTransaction to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EnvelopePublishTransaction other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.ApplyConnectSettings == other.ApplyConnectSettings ||
                    this.ApplyConnectSettings != null &&
                    this.ApplyConnectSettings.Equals(other.ApplyConnectSettings)
                ) && 
                (
                    this.EnvelopeCount == other.EnvelopeCount ||
                    this.EnvelopeCount != null &&
                    this.EnvelopeCount.Equals(other.EnvelopeCount)
                ) && 
                (
                    this.EnvelopeLevelErrorRollups == other.EnvelopeLevelErrorRollups ||
                    this.EnvelopeLevelErrorRollups != null &&
                    this.EnvelopeLevelErrorRollups.SequenceEqual(other.EnvelopeLevelErrorRollups)
                ) && 
                (
                    this.EnvelopePublishTransactionId == other.EnvelopePublishTransactionId ||
                    this.EnvelopePublishTransactionId != null &&
                    this.EnvelopePublishTransactionId.Equals(other.EnvelopePublishTransactionId)
                ) && 
                (
                    this.ErrorCount == other.ErrorCount ||
                    this.ErrorCount != null &&
                    this.ErrorCount.Equals(other.ErrorCount)
                ) && 
                (
                    this.FileLevelErrors == other.FileLevelErrors ||
                    this.FileLevelErrors != null &&
                    this.FileLevelErrors.SequenceEqual(other.FileLevelErrors)
                ) && 
                (
                    this.NoActionRequiredEnvelopeCount == other.NoActionRequiredEnvelopeCount ||
                    this.NoActionRequiredEnvelopeCount != null &&
                    this.NoActionRequiredEnvelopeCount.Equals(other.NoActionRequiredEnvelopeCount)
                ) && 
                (
                    this.ProcessedEnvelopeCount == other.ProcessedEnvelopeCount ||
                    this.ProcessedEnvelopeCount != null &&
                    this.ProcessedEnvelopeCount.Equals(other.ProcessedEnvelopeCount)
                ) && 
                (
                    this.ProcessingStatus == other.ProcessingStatus ||
                    this.ProcessingStatus != null &&
                    this.ProcessingStatus.Equals(other.ProcessingStatus)
                ) && 
                (
                    this.ResultsUri == other.ResultsUri ||
                    this.ResultsUri != null &&
                    this.ResultsUri.Equals(other.ResultsUri)
                ) && 
                (
                    this.SubmissionDate == other.SubmissionDate ||
                    this.SubmissionDate != null &&
                    this.SubmissionDate.Equals(other.SubmissionDate)
                ) && 
                (
                    this.SubmittedByUserInfo == other.SubmittedByUserInfo ||
                    this.SubmittedByUserInfo != null &&
                    this.SubmittedByUserInfo.Equals(other.SubmittedByUserInfo)
                ) && 
                (
                    this.SubmittedForPublishingEnvelopeCount == other.SubmittedForPublishingEnvelopeCount ||
                    this.SubmittedForPublishingEnvelopeCount != null &&
                    this.SubmittedForPublishingEnvelopeCount.Equals(other.SubmittedForPublishingEnvelopeCount)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)
                if (this.ApplyConnectSettings != null)
                    hash = hash * 59 + this.ApplyConnectSettings.GetHashCode();
                if (this.EnvelopeCount != null)
                    hash = hash * 59 + this.EnvelopeCount.GetHashCode();
                if (this.EnvelopeLevelErrorRollups != null)
                    hash = hash * 59 + this.EnvelopeLevelErrorRollups.GetHashCode();
                if (this.EnvelopePublishTransactionId != null)
                    hash = hash * 59 + this.EnvelopePublishTransactionId.GetHashCode();
                if (this.ErrorCount != null)
                    hash = hash * 59 + this.ErrorCount.GetHashCode();
                if (this.FileLevelErrors != null)
                    hash = hash * 59 + this.FileLevelErrors.GetHashCode();
                if (this.NoActionRequiredEnvelopeCount != null)
                    hash = hash * 59 + this.NoActionRequiredEnvelopeCount.GetHashCode();
                if (this.ProcessedEnvelopeCount != null)
                    hash = hash * 59 + this.ProcessedEnvelopeCount.GetHashCode();
                if (this.ProcessingStatus != null)
                    hash = hash * 59 + this.ProcessingStatus.GetHashCode();
                if (this.ResultsUri != null)
                    hash = hash * 59 + this.ResultsUri.GetHashCode();
                if (this.SubmissionDate != null)
                    hash = hash * 59 + this.SubmissionDate.GetHashCode();
                if (this.SubmittedByUserInfo != null)
                    hash = hash * 59 + this.SubmittedByUserInfo.GetHashCode();
                if (this.SubmittedForPublishingEnvelopeCount != null)
                    hash = hash * 59 + this.SubmittedForPublishingEnvelopeCount.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }
}
