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
    /// Contains information for transfering values between Salesforce data fields and DocuSign Tabs.
    /// </summary>
    [DataContract]
    public partial class MergeField :  IEquatable<MergeField>, IValidatableObject
    {
        public MergeField()
        {
            // Empty Constructor
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MergeField" /> class.
        /// </summary>
        /// <param name="AllowSenderToEdit">When set to **true**, the sender can modify the value of the custom tab during the sending process..</param>
        /// <param name="AllowSenderToEditMetadata">AllowSenderToEditMetadata.</param>
        /// <param name="ConfigurationType">If merge field&#39;s are being used, specifies the type of the merge field. The only  supported value is **salesforce**..</param>
        /// <param name="ConfigurationTypeMetadata">ConfigurationTypeMetadata.</param>
        /// <param name="Path">Sets the object associated with the custom tab. Currently this is the Salesforce Object..</param>
        /// <param name="PathExtended">PathExtended.</param>
        /// <param name="PathExtendedMetadata">PathExtendedMetadata.</param>
        /// <param name="PathMetadata">PathMetadata.</param>
        /// <param name="Row">Specifies the row number in a Salesforce table that the merge field value corresponds to..</param>
        /// <param name="RowMetadata">RowMetadata.</param>
        /// <param name="WriteBack">When wet to true, the information entered in the tab automatically updates the related Salesforce data when an envelope is completed..</param>
        /// <param name="WriteBackMetadata">WriteBackMetadata.</param>
        public MergeField(string AllowSenderToEdit = default(string), PropertyMetadata AllowSenderToEditMetadata = default(PropertyMetadata), string ConfigurationType = default(string), PropertyMetadata ConfigurationTypeMetadata = default(PropertyMetadata), string Path = default(string), List<PathExtendedElement> PathExtended = default(List<PathExtendedElement>), PropertyMetadata PathExtendedMetadata = default(PropertyMetadata), PropertyMetadata PathMetadata = default(PropertyMetadata), string Row = default(string), PropertyMetadata RowMetadata = default(PropertyMetadata), string WriteBack = default(string), PropertyMetadata WriteBackMetadata = default(PropertyMetadata))
        {
            this.AllowSenderToEdit = AllowSenderToEdit;
            this.AllowSenderToEditMetadata = AllowSenderToEditMetadata;
            this.ConfigurationType = ConfigurationType;
            this.ConfigurationTypeMetadata = ConfigurationTypeMetadata;
            this.Path = Path;
            this.PathExtended = PathExtended;
            this.PathExtendedMetadata = PathExtendedMetadata;
            this.PathMetadata = PathMetadata;
            this.Row = Row;
            this.RowMetadata = RowMetadata;
            this.WriteBack = WriteBack;
            this.WriteBackMetadata = WriteBackMetadata;
        }
        
        /// <summary>
        /// When set to **true**, the sender can modify the value of the custom tab during the sending process.
        /// </summary>
        /// <value>When set to **true**, the sender can modify the value of the custom tab during the sending process.</value>
        [DataMember(Name="allowSenderToEdit", EmitDefaultValue=false)]
        public string AllowSenderToEdit { get; set; }
        /// <summary>
        /// Gets or Sets AllowSenderToEditMetadata
        /// </summary>
        [DataMember(Name="allowSenderToEditMetadata", EmitDefaultValue=false)]
        public PropertyMetadata AllowSenderToEditMetadata { get; set; }
        /// <summary>
        /// If merge field&#39;s are being used, specifies the type of the merge field. The only  supported value is **salesforce**.
        /// </summary>
        /// <value>If merge field&#39;s are being used, specifies the type of the merge field. The only  supported value is **salesforce**.</value>
        [DataMember(Name="configurationType", EmitDefaultValue=false)]
        public string ConfigurationType { get; set; }
        /// <summary>
        /// Gets or Sets ConfigurationTypeMetadata
        /// </summary>
        [DataMember(Name="configurationTypeMetadata", EmitDefaultValue=false)]
        public PropertyMetadata ConfigurationTypeMetadata { get; set; }
        /// <summary>
        /// Sets the object associated with the custom tab. Currently this is the Salesforce Object.
        /// </summary>
        /// <value>Sets the object associated with the custom tab. Currently this is the Salesforce Object.</value>
        [DataMember(Name="path", EmitDefaultValue=false)]
        public string Path { get; set; }
        /// <summary>
        /// Gets or Sets PathExtended
        /// </summary>
        [DataMember(Name="pathExtended", EmitDefaultValue=false)]
        public List<PathExtendedElement> PathExtended { get; set; }
        /// <summary>
        /// Gets or Sets PathExtendedMetadata
        /// </summary>
        [DataMember(Name="pathExtendedMetadata", EmitDefaultValue=false)]
        public PropertyMetadata PathExtendedMetadata { get; set; }
        /// <summary>
        /// Gets or Sets PathMetadata
        /// </summary>
        [DataMember(Name="pathMetadata", EmitDefaultValue=false)]
        public PropertyMetadata PathMetadata { get; set; }
        /// <summary>
        /// Specifies the row number in a Salesforce table that the merge field value corresponds to.
        /// </summary>
        /// <value>Specifies the row number in a Salesforce table that the merge field value corresponds to.</value>
        [DataMember(Name="row", EmitDefaultValue=false)]
        public string Row { get; set; }
        /// <summary>
        /// Gets or Sets RowMetadata
        /// </summary>
        [DataMember(Name="rowMetadata", EmitDefaultValue=false)]
        public PropertyMetadata RowMetadata { get; set; }
        /// <summary>
        /// When wet to true, the information entered in the tab automatically updates the related Salesforce data when an envelope is completed.
        /// </summary>
        /// <value>When wet to true, the information entered in the tab automatically updates the related Salesforce data when an envelope is completed.</value>
        [DataMember(Name="writeBack", EmitDefaultValue=false)]
        public string WriteBack { get; set; }
        /// <summary>
        /// Gets or Sets WriteBackMetadata
        /// </summary>
        [DataMember(Name="writeBackMetadata", EmitDefaultValue=false)]
        public PropertyMetadata WriteBackMetadata { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MergeField {\n");
            sb.Append("  AllowSenderToEdit: ").Append(AllowSenderToEdit).Append("\n");
            sb.Append("  AllowSenderToEditMetadata: ").Append(AllowSenderToEditMetadata).Append("\n");
            sb.Append("  ConfigurationType: ").Append(ConfigurationType).Append("\n");
            sb.Append("  ConfigurationTypeMetadata: ").Append(ConfigurationTypeMetadata).Append("\n");
            sb.Append("  Path: ").Append(Path).Append("\n");
            sb.Append("  PathExtended: ").Append(PathExtended).Append("\n");
            sb.Append("  PathExtendedMetadata: ").Append(PathExtendedMetadata).Append("\n");
            sb.Append("  PathMetadata: ").Append(PathMetadata).Append("\n");
            sb.Append("  Row: ").Append(Row).Append("\n");
            sb.Append("  RowMetadata: ").Append(RowMetadata).Append("\n");
            sb.Append("  WriteBack: ").Append(WriteBack).Append("\n");
            sb.Append("  WriteBackMetadata: ").Append(WriteBackMetadata).Append("\n");
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
            return this.Equals(obj as MergeField);
        }

        /// <summary>
        /// Returns true if MergeField instances are equal
        /// </summary>
        /// <param name="other">Instance of MergeField to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MergeField other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.AllowSenderToEdit == other.AllowSenderToEdit ||
                    this.AllowSenderToEdit != null &&
                    this.AllowSenderToEdit.Equals(other.AllowSenderToEdit)
                ) && 
                (
                    this.AllowSenderToEditMetadata == other.AllowSenderToEditMetadata ||
                    this.AllowSenderToEditMetadata != null &&
                    this.AllowSenderToEditMetadata.Equals(other.AllowSenderToEditMetadata)
                ) && 
                (
                    this.ConfigurationType == other.ConfigurationType ||
                    this.ConfigurationType != null &&
                    this.ConfigurationType.Equals(other.ConfigurationType)
                ) && 
                (
                    this.ConfigurationTypeMetadata == other.ConfigurationTypeMetadata ||
                    this.ConfigurationTypeMetadata != null &&
                    this.ConfigurationTypeMetadata.Equals(other.ConfigurationTypeMetadata)
                ) && 
                (
                    this.Path == other.Path ||
                    this.Path != null &&
                    this.Path.Equals(other.Path)
                ) && 
                (
                    this.PathExtended == other.PathExtended ||
                    this.PathExtended != null &&
                    this.PathExtended.SequenceEqual(other.PathExtended)
                ) && 
                (
                    this.PathExtendedMetadata == other.PathExtendedMetadata ||
                    this.PathExtendedMetadata != null &&
                    this.PathExtendedMetadata.Equals(other.PathExtendedMetadata)
                ) && 
                (
                    this.PathMetadata == other.PathMetadata ||
                    this.PathMetadata != null &&
                    this.PathMetadata.Equals(other.PathMetadata)
                ) && 
                (
                    this.Row == other.Row ||
                    this.Row != null &&
                    this.Row.Equals(other.Row)
                ) && 
                (
                    this.RowMetadata == other.RowMetadata ||
                    this.RowMetadata != null &&
                    this.RowMetadata.Equals(other.RowMetadata)
                ) && 
                (
                    this.WriteBack == other.WriteBack ||
                    this.WriteBack != null &&
                    this.WriteBack.Equals(other.WriteBack)
                ) && 
                (
                    this.WriteBackMetadata == other.WriteBackMetadata ||
                    this.WriteBackMetadata != null &&
                    this.WriteBackMetadata.Equals(other.WriteBackMetadata)
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
                if (this.AllowSenderToEdit != null)
                    hash = hash * 59 + this.AllowSenderToEdit.GetHashCode();
                if (this.AllowSenderToEditMetadata != null)
                    hash = hash * 59 + this.AllowSenderToEditMetadata.GetHashCode();
                if (this.ConfigurationType != null)
                    hash = hash * 59 + this.ConfigurationType.GetHashCode();
                if (this.ConfigurationTypeMetadata != null)
                    hash = hash * 59 + this.ConfigurationTypeMetadata.GetHashCode();
                if (this.Path != null)
                    hash = hash * 59 + this.Path.GetHashCode();
                if (this.PathExtended != null)
                    hash = hash * 59 + this.PathExtended.GetHashCode();
                if (this.PathExtendedMetadata != null)
                    hash = hash * 59 + this.PathExtendedMetadata.GetHashCode();
                if (this.PathMetadata != null)
                    hash = hash * 59 + this.PathMetadata.GetHashCode();
                if (this.Row != null)
                    hash = hash * 59 + this.Row.GetHashCode();
                if (this.RowMetadata != null)
                    hash = hash * 59 + this.RowMetadata.GetHashCode();
                if (this.WriteBack != null)
                    hash = hash * 59 + this.WriteBack.GetHashCode();
                if (this.WriteBackMetadata != null)
                    hash = hash * 59 + this.WriteBackMetadata.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }
}