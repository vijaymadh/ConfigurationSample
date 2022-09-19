using System.Collections.Generic;

namespace EchosignRESTClient.Models.AgreementInfo
{
    public class CcInfo
    {
        public string email { get; set; }
        public string label { get; set; }
        public List<string> visiblePages { get; set; }
    }
}