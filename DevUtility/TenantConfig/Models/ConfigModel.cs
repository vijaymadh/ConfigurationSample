using System.Collections.Generic;

namespace ConfigurationValidation.TenantConfig.Models
{
    class ConfigModel
    {
        public string messages { get; set; }
        public List<Data> data { get; set; }
        public bool hasMoreData { get; set; }
        public string pagingData { get; set; }
    }
}
