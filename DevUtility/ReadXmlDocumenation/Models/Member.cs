using System.Collections.Generic;
using System.Text;

namespace ConfigurationValidation.ReadXmlDocumenation.Models
{
    class Member
    {
        public string Name { get; set; }

        private string _type;

        public string Type
        {
            get
            {
                switch (_type)
                {
                    case "T":
                        return "Type";
                    case "P":
                        return "Property";
                    case "M":
                        return "Method";
                    case "F":
                        return "Field";
                    default:
                        return _type;
                }
            }
            set { _type = value; }
        }

        public string Summary { get; set; }

        private Dictionary<string, string> _parameters;
        public Dictionary<string, string> Parameters { set { _parameters = value; } }

        public string ParamString
        {
            get
            {
                var paramSb = new StringBuilder();
                foreach (var param in _parameters)
                {
                    paramSb.Append($"Name:{param.Key}, Value:{param.Value}\n");
                }
                return paramSb.ToString();
            }
        }
    }
}
