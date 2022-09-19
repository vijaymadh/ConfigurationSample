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
    /// ConditionalRecipientRuleFilter
    /// </summary>
    [DataContract]
    public partial class ConditionalRecipientRuleFilter :  IEquatable<ConditionalRecipientRuleFilter>, IValidatableObject
    {
        public ConditionalRecipientRuleFilter()
        {
            // Empty Constructor
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConditionalRecipientRuleFilter" /> class.
        /// </summary>
        /// <param name="Operator">Operator.</param>
        /// <param name="RecipientId">Unique for the recipient. It is used by the tab element to indicate which recipient is to sign the Document..</param>
        /// <param name="Scope">Scope.</param>
        /// <param name="TabId">The unique identifier for the tab. The tabid can be retrieved with the [ML:GET call].     .</param>
        /// <param name="TabLabel">The label string associated with the tab..</param>
        /// <param name="TabType">TabType.</param>
        /// <param name="Value">Specifies the value of the tab. .</param>
        public ConditionalRecipientRuleFilter(string Operator = default(string), string RecipientId = default(string), string Scope = default(string), string TabId = default(string), string TabLabel = default(string), string TabType = default(string), string Value = default(string))
        {
            this.Operator = Operator;
            this.RecipientId = RecipientId;
            this.Scope = Scope;
            this.TabId = TabId;
            this.TabLabel = TabLabel;
            this.TabType = TabType;
            this.Value = Value;
        }
        
        /// <summary>
        /// Gets or Sets Operator
        /// </summary>
        [DataMember(Name="operator", EmitDefaultValue=false)]
        public string Operator { get; set; }
        /// <summary>
        /// Unique for the recipient. It is used by the tab element to indicate which recipient is to sign the Document.
        /// </summary>
        /// <value>Unique for the recipient. It is used by the tab element to indicate which recipient is to sign the Document.</value>
        [DataMember(Name="recipientId", EmitDefaultValue=false)]
        public string RecipientId { get; set; }
        /// <summary>
        /// Gets or Sets Scope
        /// </summary>
        [DataMember(Name="scope", EmitDefaultValue=false)]
        public string Scope { get; set; }
        /// <summary>
        /// The unique identifier for the tab. The tabid can be retrieved with the [ML:GET call].     
        /// </summary>
        /// <value>The unique identifier for the tab. The tabid can be retrieved with the [ML:GET call].     </value>
        [DataMember(Name="tabId", EmitDefaultValue=false)]
        public string TabId { get; set; }
        /// <summary>
        /// The label string associated with the tab.
        /// </summary>
        /// <value>The label string associated with the tab.</value>
        [DataMember(Name="tabLabel", EmitDefaultValue=false)]
        public string TabLabel { get; set; }
        /// <summary>
        /// Gets or Sets TabType
        /// </summary>
        [DataMember(Name="tabType", EmitDefaultValue=false)]
        public string TabType { get; set; }
        /// <summary>
        /// Specifies the value of the tab. 
        /// </summary>
        /// <value>Specifies the value of the tab. </value>
        [DataMember(Name="value", EmitDefaultValue=false)]
        public string Value { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ConditionalRecipientRuleFilter {\n");
            sb.Append("  Operator: ").Append(Operator).Append("\n");
            sb.Append("  RecipientId: ").Append(RecipientId).Append("\n");
            sb.Append("  Scope: ").Append(Scope).Append("\n");
            sb.Append("  TabId: ").Append(TabId).Append("\n");
            sb.Append("  TabLabel: ").Append(TabLabel).Append("\n");
            sb.Append("  TabType: ").Append(TabType).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
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
            return this.Equals(obj as ConditionalRecipientRuleFilter);
        }

        /// <summary>
        /// Returns true if ConditionalRecipientRuleFilter instances are equal
        /// </summary>
        /// <param name="other">Instance of ConditionalRecipientRuleFilter to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ConditionalRecipientRuleFilter other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Operator == other.Operator ||
                    this.Operator != null &&
                    this.Operator.Equals(other.Operator)
                ) && 
                (
                    this.RecipientId == other.RecipientId ||
                    this.RecipientId != null &&
                    this.RecipientId.Equals(other.RecipientId)
                ) && 
                (
                    this.Scope == other.Scope ||
                    this.Scope != null &&
                    this.Scope.Equals(other.Scope)
                ) && 
                (
                    this.TabId == other.TabId ||
                    this.TabId != null &&
                    this.TabId.Equals(other.TabId)
                ) && 
                (
                    this.TabLabel == other.TabLabel ||
                    this.TabLabel != null &&
                    this.TabLabel.Equals(other.TabLabel)
                ) && 
                (
                    this.TabType == other.TabType ||
                    this.TabType != null &&
                    this.TabType.Equals(other.TabType)
                ) && 
                (
                    this.Value == other.Value ||
                    this.Value != null &&
                    this.Value.Equals(other.Value)
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
                if (this.Operator != null)
                    hash = hash * 59 + this.Operator.GetHashCode();
                if (this.RecipientId != null)
                    hash = hash * 59 + this.RecipientId.GetHashCode();
                if (this.Scope != null)
                    hash = hash * 59 + this.Scope.GetHashCode();
                if (this.TabId != null)
                    hash = hash * 59 + this.TabId.GetHashCode();
                if (this.TabLabel != null)
                    hash = hash * 59 + this.TabLabel.GetHashCode();
                if (this.TabType != null)
                    hash = hash * 59 + this.TabType.GetHashCode();
                if (this.Value != null)
                    hash = hash * 59 + this.Value.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }
}
