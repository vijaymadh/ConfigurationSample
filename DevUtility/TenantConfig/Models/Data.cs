using System.Collections.Generic;

namespace ConfigurationValidation.TenantConfig.Models
{
    public class Data
    {
        public TenantEntity tenantEntity { get; set; }
        public List<Tenant> Tenants { get; set; }
        public string timestamp { get; set; }
    }
}