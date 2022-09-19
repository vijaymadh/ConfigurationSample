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
    /// NotificationDefaultSettings
    /// </summary>
    [DataContract]
    public partial class NotificationDefaultSettings :  IEquatable<NotificationDefaultSettings>, IValidatableObject
    {
        public NotificationDefaultSettings()
        {
            // Empty Constructor
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationDefaultSettings" /> class.
        /// </summary>
        /// <param name="SenderEmailNotifications">SenderEmailNotifications.</param>
        /// <param name="SignerEmailNotifications">SignerEmailNotifications.</param>
        public NotificationDefaultSettings(SenderEmailNotifications SenderEmailNotifications = default(SenderEmailNotifications), SignerEmailNotifications SignerEmailNotifications = default(SignerEmailNotifications))
        {
            this.SenderEmailNotifications = SenderEmailNotifications;
            this.SignerEmailNotifications = SignerEmailNotifications;
        }
        
        /// <summary>
        /// Gets or Sets SenderEmailNotifications
        /// </summary>
        [DataMember(Name="senderEmailNotifications", EmitDefaultValue=false)]
        public SenderEmailNotifications SenderEmailNotifications { get; set; }
        /// <summary>
        /// Gets or Sets SignerEmailNotifications
        /// </summary>
        [DataMember(Name="signerEmailNotifications", EmitDefaultValue=false)]
        public SignerEmailNotifications SignerEmailNotifications { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class NotificationDefaultSettings {\n");
            sb.Append("  SenderEmailNotifications: ").Append(SenderEmailNotifications).Append("\n");
            sb.Append("  SignerEmailNotifications: ").Append(SignerEmailNotifications).Append("\n");
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
            return this.Equals(obj as NotificationDefaultSettings);
        }

        /// <summary>
        /// Returns true if NotificationDefaultSettings instances are equal
        /// </summary>
        /// <param name="other">Instance of NotificationDefaultSettings to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NotificationDefaultSettings other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.SenderEmailNotifications == other.SenderEmailNotifications ||
                    this.SenderEmailNotifications != null &&
                    this.SenderEmailNotifications.Equals(other.SenderEmailNotifications)
                ) && 
                (
                    this.SignerEmailNotifications == other.SignerEmailNotifications ||
                    this.SignerEmailNotifications != null &&
                    this.SignerEmailNotifications.Equals(other.SignerEmailNotifications)
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
                if (this.SenderEmailNotifications != null)
                    hash = hash * 59 + this.SenderEmailNotifications.GetHashCode();
                if (this.SignerEmailNotifications != null)
                    hash = hash * 59 + this.SignerEmailNotifications.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }
}
