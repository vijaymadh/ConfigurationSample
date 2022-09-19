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
    /// ReportInProductSaveResponse
    /// </summary>
    [DataContract]
    public partial class ReportInProductSaveResponse :  IEquatable<ReportInProductSaveResponse>, IValidatableObject
    {
        public ReportInProductSaveResponse()
        {
            // Empty Constructor
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportInProductSaveResponse" /> class.
        /// </summary>
        /// <param name="ReportCustomizedId">ReportCustomizedId.</param>
        public ReportInProductSaveResponse(string ReportCustomizedId = default(string))
        {
            this.ReportCustomizedId = ReportCustomizedId;
        }
        
        /// <summary>
        /// Gets or Sets ReportCustomizedId
        /// </summary>
        [DataMember(Name="reportCustomizedId", EmitDefaultValue=false)]
        public string ReportCustomizedId { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ReportInProductSaveResponse {\n");
            sb.Append("  ReportCustomizedId: ").Append(ReportCustomizedId).Append("\n");
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
            return this.Equals(obj as ReportInProductSaveResponse);
        }

        /// <summary>
        /// Returns true if ReportInProductSaveResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of ReportInProductSaveResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ReportInProductSaveResponse other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.ReportCustomizedId == other.ReportCustomizedId ||
                    this.ReportCustomizedId != null &&
                    this.ReportCustomizedId.Equals(other.ReportCustomizedId)
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
                if (this.ReportCustomizedId != null)
                    hash = hash * 59 + this.ReportCustomizedId.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }
}
