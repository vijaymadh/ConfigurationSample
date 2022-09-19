using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsignDifinition;

namespace DocuSign
{
    public class DocuSign : IEsign
    {
        public virtual string Implementation => "DocuSign";

        public virtual string OverrideTest()
        {
            return "I will implement DocuSign.OverrideTest";
        }

        public virtual string Send()
        {
            return "I will implement DocuSign.Send";
        }
    }
}
