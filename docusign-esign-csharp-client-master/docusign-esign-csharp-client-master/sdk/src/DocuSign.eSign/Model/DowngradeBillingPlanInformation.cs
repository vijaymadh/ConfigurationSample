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
    /// DowngradeBillingPlanInformation
    /// </summary>
    [DataContract]
    public partial class DowngradeBillingPlanInformation :  IEquatable<DowngradeBillingPlanInformation>, IValidatableObject
    {
        public DowngradeBillingPlanInformation()
        {
            // Empty Constructor
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DowngradeBillingPlanInformation" /> class.
        /// </summary>
        /// <param name="DowngradeEventType">DowngradeEventType.</param>
        /// <param name="PlanInformation">PlanInformation.</param>
        /// <param name="PromoCode">PromoCode.</param>
        /// <param name="SaleDiscount">SaleDiscount.</param>
        /// <param name="SaleDiscountPeriods">SaleDiscountPeriods.</param>
        /// <param name="SaleDiscountType">SaleDiscountType.</param>
        public DowngradeBillingPlanInformation(string DowngradeEventType = default(string), PlanInformation PlanInformation = default(PlanInformation), string PromoCode = default(string), string SaleDiscount = default(string), string SaleDiscountPeriods = default(string), string SaleDiscountType = default(string))
        {
            this.DowngradeEventType = DowngradeEventType;
            this.PlanInformation = PlanInformation;
            this.PromoCode = PromoCode;
            this.SaleDiscount = SaleDiscount;
            this.SaleDiscountPeriods = SaleDiscountPeriods;
            this.SaleDiscountType = SaleDiscountType;
        }
        
        /// <summary>
        /// Gets or Sets DowngradeEventType
        /// </summary>
        [DataMember(Name="downgradeEventType", EmitDefaultValue=false)]
        public string DowngradeEventType { get; set; }
        /// <summary>
        /// Gets or Sets PlanInformation
        /// </summary>
        [DataMember(Name="planInformation", EmitDefaultValue=false)]
        public PlanInformation PlanInformation { get; set; }
        /// <summary>
        /// Gets or Sets PromoCode
        /// </summary>
        [DataMember(Name="promoCode", EmitDefaultValue=false)]
        public string PromoCode { get; set; }
        /// <summary>
        /// Gets or Sets SaleDiscount
        /// </summary>
        [DataMember(Name="saleDiscount", EmitDefaultValue=false)]
        public string SaleDiscount { get; set; }
        /// <summary>
        /// Gets or Sets SaleDiscountPeriods
        /// </summary>
        [DataMember(Name="saleDiscountPeriods", EmitDefaultValue=false)]
        public string SaleDiscountPeriods { get; set; }
        /// <summary>
        /// Gets or Sets SaleDiscountType
        /// </summary>
        [DataMember(Name="saleDiscountType", EmitDefaultValue=false)]
        public string SaleDiscountType { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DowngradeBillingPlanInformation {\n");
            sb.Append("  DowngradeEventType: ").Append(DowngradeEventType).Append("\n");
            sb.Append("  PlanInformation: ").Append(PlanInformation).Append("\n");
            sb.Append("  PromoCode: ").Append(PromoCode).Append("\n");
            sb.Append("  SaleDiscount: ").Append(SaleDiscount).Append("\n");
            sb.Append("  SaleDiscountPeriods: ").Append(SaleDiscountPeriods).Append("\n");
            sb.Append("  SaleDiscountType: ").Append(SaleDiscountType).Append("\n");
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
            return this.Equals(obj as DowngradeBillingPlanInformation);
        }

        /// <summary>
        /// Returns true if DowngradeBillingPlanInformation instances are equal
        /// </summary>
        /// <param name="other">Instance of DowngradeBillingPlanInformation to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DowngradeBillingPlanInformation other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.DowngradeEventType == other.DowngradeEventType ||
                    this.DowngradeEventType != null &&
                    this.DowngradeEventType.Equals(other.DowngradeEventType)
                ) && 
                (
                    this.PlanInformation == other.PlanInformation ||
                    this.PlanInformation != null &&
                    this.PlanInformation.Equals(other.PlanInformation)
                ) && 
                (
                    this.PromoCode == other.PromoCode ||
                    this.PromoCode != null &&
                    this.PromoCode.Equals(other.PromoCode)
                ) && 
                (
                    this.SaleDiscount == other.SaleDiscount ||
                    this.SaleDiscount != null &&
                    this.SaleDiscount.Equals(other.SaleDiscount)
                ) && 
                (
                    this.SaleDiscountPeriods == other.SaleDiscountPeriods ||
                    this.SaleDiscountPeriods != null &&
                    this.SaleDiscountPeriods.Equals(other.SaleDiscountPeriods)
                ) && 
                (
                    this.SaleDiscountType == other.SaleDiscountType ||
                    this.SaleDiscountType != null &&
                    this.SaleDiscountType.Equals(other.SaleDiscountType)
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
                if (this.DowngradeEventType != null)
                    hash = hash * 59 + this.DowngradeEventType.GetHashCode();
                if (this.PlanInformation != null)
                    hash = hash * 59 + this.PlanInformation.GetHashCode();
                if (this.PromoCode != null)
                    hash = hash * 59 + this.PromoCode.GetHashCode();
                if (this.SaleDiscount != null)
                    hash = hash * 59 + this.SaleDiscount.GetHashCode();
                if (this.SaleDiscountPeriods != null)
                    hash = hash * 59 + this.SaleDiscountPeriods.GetHashCode();
                if (this.SaleDiscountType != null)
                    hash = hash * 59 + this.SaleDiscountType.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }
}