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
    /// SettingsMetadata
    /// </summary>
    [DataContract]
    public partial class SettingsMetadata :  IEquatable<SettingsMetadata>, IValidatableObject
    {
        public SettingsMetadata()
        {
            // Empty Constructor
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsMetadata" /> class.
        /// </summary>
        /// <param name="Is21CFRPart11">When set to **true**, indicates that this module is enabled on the account..</param>
        /// <param name="Options">Options.</param>
        /// <param name="Rights">Rights.</param>
        /// <param name="UiHint">UiHint.</param>
        /// <param name="UiOrder">UiOrder.</param>
        /// <param name="UiType">UiType.</param>
        public SettingsMetadata(string Is21CFRPart11 = default(string), List<string> Options = default(List<string>), string Rights = default(string), string UiHint = default(string), string UiOrder = default(string), string UiType = default(string))
        {
            this.Is21CFRPart11 = Is21CFRPart11;
            this.Options = Options;
            this.Rights = Rights;
            this.UiHint = UiHint;
            this.UiOrder = UiOrder;
            this.UiType = UiType;
        }
        
        /// <summary>
        /// When set to **true**, indicates that this module is enabled on the account.
        /// </summary>
        /// <value>When set to **true**, indicates that this module is enabled on the account.</value>
        [DataMember(Name="is21CFRPart11", EmitDefaultValue=false)]
        public string Is21CFRPart11 { get; set; }
        /// <summary>
        /// Gets or Sets Options
        /// </summary>
        [DataMember(Name="options", EmitDefaultValue=false)]
        public List<string> Options { get; set; }
        /// <summary>
        /// Gets or Sets Rights
        /// </summary>
        [DataMember(Name="rights", EmitDefaultValue=false)]
        public string Rights { get; set; }
        /// <summary>
        /// Gets or Sets UiHint
        /// </summary>
        [DataMember(Name="uiHint", EmitDefaultValue=false)]
        public string UiHint { get; set; }
        /// <summary>
        /// Gets or Sets UiOrder
        /// </summary>
        [DataMember(Name="uiOrder", EmitDefaultValue=false)]
        public string UiOrder { get; set; }
        /// <summary>
        /// Gets or Sets UiType
        /// </summary>
        [DataMember(Name="uiType", EmitDefaultValue=false)]
        public string UiType { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SettingsMetadata {\n");
            sb.Append("  Is21CFRPart11: ").Append(Is21CFRPart11).Append("\n");
            sb.Append("  Options: ").Append(Options).Append("\n");
            sb.Append("  Rights: ").Append(Rights).Append("\n");
            sb.Append("  UiHint: ").Append(UiHint).Append("\n");
            sb.Append("  UiOrder: ").Append(UiOrder).Append("\n");
            sb.Append("  UiType: ").Append(UiType).Append("\n");
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
            return this.Equals(obj as SettingsMetadata);
        }

        /// <summary>
        /// Returns true if SettingsMetadata instances are equal
        /// </summary>
        /// <param name="other">Instance of SettingsMetadata to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SettingsMetadata other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Is21CFRPart11 == other.Is21CFRPart11 ||
                    this.Is21CFRPart11 != null &&
                    this.Is21CFRPart11.Equals(other.Is21CFRPart11)
                ) && 
                (
                    this.Options == other.Options ||
                    this.Options != null &&
                    this.Options.SequenceEqual(other.Options)
                ) && 
                (
                    this.Rights == other.Rights ||
                    this.Rights != null &&
                    this.Rights.Equals(other.Rights)
                ) && 
                (
                    this.UiHint == other.UiHint ||
                    this.UiHint != null &&
                    this.UiHint.Equals(other.UiHint)
                ) && 
                (
                    this.UiOrder == other.UiOrder ||
                    this.UiOrder != null &&
                    this.UiOrder.Equals(other.UiOrder)
                ) && 
                (
                    this.UiType == other.UiType ||
                    this.UiType != null &&
                    this.UiType.Equals(other.UiType)
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
                if (this.Is21CFRPart11 != null)
                    hash = hash * 59 + this.Is21CFRPart11.GetHashCode();
                if (this.Options != null)
                    hash = hash * 59 + this.Options.GetHashCode();
                if (this.Rights != null)
                    hash = hash * 59 + this.Rights.GetHashCode();
                if (this.UiHint != null)
                    hash = hash * 59 + this.UiHint.GetHashCode();
                if (this.UiOrder != null)
                    hash = hash * 59 + this.UiOrder.GetHashCode();
                if (this.UiType != null)
                    hash = hash * 59 + this.UiType.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }
}
