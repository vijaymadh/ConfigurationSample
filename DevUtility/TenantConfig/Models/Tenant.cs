using System.Collections.Generic;

namespace ConfigurationValidation.TenantConfig.Models
{
    public class Tenant
    {
        public TenantInfo tenant { get; set; }
        public List<tenantPropertyGroup> tenantPropertyGroups { get; set; }
        public string timestamp { get; set; }
    }
}