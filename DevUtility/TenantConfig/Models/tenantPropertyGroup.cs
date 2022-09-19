using System.Collections.Generic;

namespace ConfigurationValidation.TenantConfig.Models
{
    public class tenantPropertyGroup
    {
        public string id { get; set; }
        public string priority { get; set; }
        public List<Config> properties { get; set; }
    }
}