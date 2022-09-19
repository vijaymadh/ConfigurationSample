namespace ConfigurationValidation.TenantConfig.Models
{
    public class Config
    {
        public string Id { get; set; }
        public bool IsEncrypted { get; set; }
        public string OverrideType { get; set; }
        public string ValueType { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public string DefaultValue { get; set; }
        public bool IsReadOnly { get; set; }
        public string ErrorMessageDescription { get; set; }
        public string Name { get; set; }
    }
}