using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocuSign;
using EsignDifinition;

namespace CustomDocuSign
{
    public class CustomDocuSign : DocuSign.DocuSign, IEsign
    {
        public new string Implementation => base.Implementation;

        public new string Send()
        {
            return base.Send();
        }

        public override string OverrideTest()
        {
            return "I will implement CustomDocuSign.OverrideTest";
        }
    }
}
