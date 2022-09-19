using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    class ConfigDesig
    {
        public string messages { get; set; }
        public List<Data> data { get; set; }
        public bool hasMoreData { get; set; }
        public string pagingData { get; set; }
    }

    public class Data
    {
        public TenantEntity tenantEntity { get; set; }
        public List<Tenant> Tenants { get; set; }
        public string timestamp { get; set; }
    }

    public class TenantEntity
    {
        public string id { get; set; }
        public string tenantEntityCode { get; set; }
        public string tenantEntityName { get; set; }

    }

    public class Tenant
    {
        public TenantInfo tenant { get; set; }
        public List<tenantPropertyGroup> tenantPropertyGroups { get; set; }
        public string timestamp { get; set; }
    }
    public class TenantInfo
    {
        public string id { get; set; }
        public string tenantEntityId { get; set; }
        public string tenantCode { get; set; }
        public string tenantName { get; set; }
        public string tenantType { get; set; }
    }

    public class tenantPropertyGroup
    {
        public string id { get; set; }
        public string priority { get; set; }
        public List<Config> properties { get; set; }
    }
    public class Config
    {
        public string id { get; set; }
        public bool isEncrypted { get; set; }
        public string overrideType { get; set; }
        public string valueType { get; set; }
        public string value { get; set; }
        public string description { get; set; }
        public string defaultValue { get; set; }
        public bool isReadOnly { get; set; }
        public string errorMessageDescription { get; set; }
        public string name { get; set; }
    }
}
